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
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Rest post api to return success message by creating new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        
        [Route("new")]
        [HttpPost]
        public async Task< ActionResult<String>> CreateNewUser(User user)
        {
            try
            {
                //Business logic to call user servic method which returns success message after creating new user
                var result =await _userService.CreateNewUser(user);
                return result;
            }
            catch (Exception exception)
            {
                return BadRequest(exception.ToString());
            }

        }

        /// <summary>
        /// Rest post api to return 1 after updation of user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        
        [Route("edit")]
        [HttpPut]
        public async Task<ActionResult<int>>  ReviseUser(User user)
        {
            try
            {
                //Business logic to call user servic method which returns 1 on successfull updation of user
                var result =await _userService.UpdateUser(user);
                return result;
            }
            catch (Exception exception)
            {
                return BadRequest(exception.ToString());
            }

        }

        /// <summary>
        /// Rest post api to return 1 after deletion of user
        /// </summary>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <returns></returns>
        
        [Route("delete")]
        [HttpDelete]
        public async Task< ActionResult<int>> Destroyuser(String firstname, String lastname)
        {
            try
            {
                //Business logic to call user servic method which returns 1 on successfull deletion of user
                var result =await  _userService.RemoveUser(firstname, lastname);
                return result;
            }
            catch (Exception exception)
            {
                return BadRequest(exception.ToString());
            }

        }

       
        /// <summary>
        /// Rest post api to return list of users
        /// </summary>
        /// <returns></returns>
        
        [Route("alluser")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> AllUsers()
        {
            try
            {
                //Business logic to call admin servic method which returns list of users
                var result =await _userService.GetAllUsers();
                return result as List<User>;
            }
            catch (Exception exception)
            {
                return BadRequest(exception.ToString());
            }

        }

        /// <summary>
        /// Rest post api to return  user filtered by first name
        /// </summary>
        /// <param name="firstname"></param>
        /// <returns></returns>
        
        [Route("byfirstname")]
        [HttpGet]
        public async Task<ActionResult<User>> SearchByFirstName(String firstname)
        {
            try
            {
                //Business logic to call admin servic method which returns  user filtered by first name
                var result =await _userService.SearchUserByFirstName(firstname);
                return result;
            }
            catch (Exception exception)
            {
                return BadRequest(exception.ToString());
            }

        }

        /// <summary>
        /// Rest post api to return  user filtered by email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        
        [Route("byemail")]
        [HttpGet]
        public async Task<ActionResult<User>> SearchByEmail(String email)
        {
            try
            {
                //Business logic to call admin servic method which returns  user filtered by email id
                var result =await _userService.SearchUserByEmail(email);
                return result;
            }
            catch (Exception exception)
            {
                return BadRequest(exception.ToString());
            }

        }

        /// <summary>
        /// Rest post api to return  user filtered by mobile number
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns></returns>
        
        [Route("bymobile")]
        [HttpGet]
        public async Task<ActionResult<User>> SearchByMobileNumber(long mobile)
        {
            try
            {
                //Business logic to call admin servic method which returns  user filtered by mobile number
                var result =await _userService.SearchUserByMobile(mobile);
                return result;
            }
            catch (Exception exception)
            {
                return BadRequest(exception.ToString());
            }

        }

        /// <summary>
        /// Rest post api to return  user filtered by Skill range
        /// </summary>
        /// <param name="startvalue"></param>
        /// <param name="endvalue"></param>
        /// <returns></returns>
        
        [Route("byskillrange")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> SearchBySkillRange(int startvalue,int endvalue)
        {
            try
            {
                //Business logic to call admin servic method which returns list of  users filtered by range value
                var result =await _userService.SearchUserBySkillRange(startvalue,endvalue);
                return result as List<User>;
            }
            catch (Exception exception)
            {
                return BadRequest(exception.ToString());
            }

        }
    }
}