using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkillTracker.BusinessLayer.Interface;
using SkillTracker.Entities;

namespace SkillTracker.API.Controllers
{
    [Route("api/admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        [Route("/api/admin/test")]
        [HttpGet]
        public ActionResult<String> Get()
        {
            try
            {
               
                return "Hi";
            }
            catch (Exception exception)
            {
                return BadRequest(exception.ToString());
            }

        }
        //Rest post api to return list of users
        [Route("/api/admin/alluser")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<User>>> AllUsers()
        {
            try
            {
                //Business logic to call admin servic method which returns list of users
                var result =  _adminService.GetAllUsers();
                return result as List<User>;
            }
            catch (Exception exception)
            {
                return BadRequest(exception.ToString());
            }

        }

        //Rest post api to return  user filtered by first name
        [Route("/api/admin/byfirstname")]
        [HttpPost]
        public async Task<ActionResult<User>> SearchByFirstName(String firstname)
        {
            try
            {
                //Business logic to call admin servic method which returns  user filtered by first name
                var result = _adminService.SearchUserByFirstName(firstname);
                return result ;
            }
            catch (Exception exception)
            {
                return BadRequest(exception.ToString());
            }

        }

        //Rest post api to return  user filtered by email
        [Route("/api/admin/byemail")]
        [HttpPost]
        public async Task<ActionResult<User>> SearchByEmail(String email)
        {
            try
            {
                //Business logic to call admin servic method which returns  user filtered by email id
                var result = _adminService.SearchUserByEmail(email);
                return result;
            }
            catch (Exception exception)
            {
                return BadRequest(exception.ToString());
            }

        }

        //Rest post api to return  user filtered by mobile number
        [Route("/api/admin/bymobile")]
        [HttpPost]
        public async Task<ActionResult<User>> SearchByMobileNumber(long mobile)
        {
            try
            {
                //Business logic to call admin servic method which returns  user filtered by mobile number
                var result = _adminService.SearchUserByMobile(mobile);
                return result;
            }
            catch (Exception exception)
            {
                return BadRequest(exception.ToString());
            }

        }

        //Rest post api to return  user filtered by Skill range
        [Route("/api/admin/byskillrange")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<User>>> SearchBySkillRange(int startvalue)
        {
            try
            {
                //Business logic to call admin servic method which returns list of  users filtered by range value
                var result = _adminService.SearchUserBySkillRange(startvalue);
                return result as List<User>; 
            }
            catch (Exception exception)
            {
                return BadRequest(exception.ToString());
            }

        }
    }
}