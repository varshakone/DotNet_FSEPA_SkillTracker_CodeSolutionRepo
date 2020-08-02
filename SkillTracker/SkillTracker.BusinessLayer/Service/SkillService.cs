using MongoDB.Driver;
using SkillTracker.BusinessLayer.Interface;
using SkillTracker.BusinessLayer.Service.Repository;
using SkillTracker.DataLayer;
using SkillTracker.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SkillTracker.BusinessLayer.Service
{
    public class SkillService : ISkillService
    {

        private readonly ISkillRepository _skillRepository;

        /// <summary>
        /// Create Object of type IUserRepository
        /// </summary>
        /// <param name="userRepository"></param>
        public SkillService(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        /// <summary>
        /// Save new skill upgarded by full stack engineer into database
        /// </summary>
        /// <param name="skill"></param>
        /// <returns></returns>
        
        public async Task<string> AddNewSkill(Skill skill)
        {
            //Business Logic to call SkillRepository method
            try
            {
              var result = await _skillRepository.AddNewSkill(skill);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// delete skill of full stack engineer from database
        /// </summary>
        /// <param name="skillname"></param>
        /// <returns></returns>
       public async Task<int> DeleteSkill(string skillname)
        {
            //Business Logic to call SkillRepository method
            try
            {
                var result = await _skillRepository.DeleteSkill(skillname);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// update skill upgarded by full stack engineer from database
        /// </summary>
        /// <param name="skill"></param>
        /// <returns></returns>

        public async Task<int> EditSkill(Skill skill)
        {
            //Business Logic to call SkillRepository method
            try
            {
                var result = await _skillRepository.EditSkill(skill);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
