using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Moq;
using SkillTracker.DataLayer;
using SkillTracker.Entities;
using SkillTracker.Tests.Utility;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SkillTracker.Tests.TestCases
{
    [CollectionDefinition("parallel", DisableParallelization = false)]
    public class DatabaseConnectionTest
    {
       
        static FileUtility fileUtility;
        MongoDBUtility MongoDBUtility;
        IConfigurationRoot config;

        public DatabaseConnectionTest()
        {
            MongoDBUtility = new MongoDBUtility();
           config = new ConfigurationBuilder().AddJsonFile("appsettings.test.json").Build();
        }

        static DatabaseConnectionTest()
        {
            fileUtility = new FileUtility();
            fileUtility.FilePath = "../../../../output_batabase_revised.txt";
            fileUtility.CreateTextFile();
        }
        [Fact]
        public void MongoSkillTrackerDBContex_Constructor_Success()
        {
            try
            {
                                        //Action
                var context = MongoDBUtility.MongoDBContext ;
                if (context != null)
                {
                    string testResult = "MongoSkillTrackerDBContext_Constructor_Success=" + "True";

                    // Write test case result in text file
                    fileUtility.WriteTestCaseResuItInText(testResult);



                }
                //Assert 
                Assert.NotNull(context);
            }
            catch (Exception ex)
            {
                string testResult = "MongoSkillTrackerDBContext_Constructor_Success=" + "False";

                // Write test case result in text file
                fileUtility.WriteTestCaseResuItInText(testResult);
                var res =ex.Message;
            }
        }


        [Fact]
        public void MongoSkillTrackerDBContext_GetCollection_ValidName_Success()
        {
            try
            {
                //Arrange
                        

               // _mockClient.Setup(c => c.GetDatabase(_mockOptions.Object.Value.DatabaseName, null)).Returns(_mockDB.Object);

                // Action
                var context =MongoDBUtility.MongoDBContext;
              var skillCollection = context.GetCollection<Skill>("Skills");
                var userCollection = context.GetCollection<User>("Users");
                if (skillCollection != null && userCollection !=null)
                {
                    string testResult = "MongoSkillTrackerDBContext_GetCollection_ValidName_Success=" + "True";

                    // Write test case result in text file
                    fileUtility.WriteTestCaseResuItInText(testResult);
                }
                //Assert 
                Assert.NotNull(skillCollection);
                Assert.NotNull(userCollection);
            }
            catch (Exception ex)
            {
                string testResult = "MongoSkillTrackerDBContext_GetCollection_ValidName_Success=" + "False";

                // Write test case result in text file
                fileUtility.WriteTestCaseResuItInText(testResult);
                var res = ex.Message;
            }
        }
    }
}

