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
    
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly ISkillService _skillService;
        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        //Rest post api to return success message after creating skill
        [Route("api/skill/new")]
        [HttpPost]
        public async Task<ActionResult<String>> NewSkill(Skill skill)
        {
            try
            {
                //Business logic to call user servic method which returns success message after creating new skill
                var result = _skillService.AddNewSkill(skill);
                return result;
            }
            catch (Exception exception)
            {
                return BadRequest(exception.ToString());
            }

        }

        //Rest post api to return 1 after updation of skill
        [Route("api/skill/edit")]
        [HttpPost]
        public async Task<ActionResult<int>> ReviseSkill(Skill skill)
        {
            try
            { 
                //Business logic to call skill servic method which returns 1 on successfull updation of skill
                var result = _skillService.EditSkill(skill);
                return result;
            }
            catch (Exception exception)
            {
                return BadRequest(exception.ToString());
            }

        }

        //Rest post api to return 1 after deletion of skill
        [Route("api/skill/delete")]
        [HttpPost]
        public async Task<ActionResult<int>> DestroySkill (String SkillName)
        {
            try
            {
                //Business logic to call skill servic method which returns 1 on successfull deletion of skill
                var result = _skillService.DeleteSkill(SkillName);
                return result;
            }
            catch (Exception exception)
            {
                return BadRequest(exception.ToString());
            }

        }
    }
}