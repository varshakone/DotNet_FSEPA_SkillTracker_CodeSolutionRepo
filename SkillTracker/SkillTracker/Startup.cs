using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.Web.CodeGeneration;
using SkillTracker.BusinessLayer.Interface;
using SkillTracker.BusinessLayer.Service;
using SkillTracker.DataLayer;
using Microsoft.Extensions.Logging;

namespace SkillTracker.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.Configure<MongoSettings>(options => {

                options.DatabaseName = Configuration.GetSection("MongoConnection:DatabaseName").Value;
                options.Connection = Configuration.GetSection("MongoConnection:Connection").Value;

                if (options.Connection == null && options.DatabaseName == null)
                {
                    options.Connection =
                    "mongodb://Localhost:27017";
                    options.DatabaseName = "SkillTrackerDB";
                }
            }
            );
            services.AddScoped<ISkillService, SkillService>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IMongoDBContext, MongoDBContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseStatusCodePages(async context =>
            {
                var code = context.HttpContext.Response.StatusCode;
                if (code == 404)
                {
                    logger.Log(LogLevel.Error, null, "log message");
                }
            });
            app.UseHttpsRedirection();

            app.UseMvcWithDefaultRoute();
        }
    }
}
