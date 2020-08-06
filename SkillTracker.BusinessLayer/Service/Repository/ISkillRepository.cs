using SkillTracker.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SkillTracker.BusinessLayer.Service.Repository
{
   public interface ISkillRepository
    {
        Task<String> AddNewSkill(Skill skill);
        Task<int> EditSkill(Skill skill);
        Task<int> DeleteSkill(String skillname);
    }
}
