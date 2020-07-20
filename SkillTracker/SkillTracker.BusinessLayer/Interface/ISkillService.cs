using SkillTracker.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SkillTracker.BusinessLayer.Interface
{
   public interface ISkillService
    {
        String AddNewSkill(Skill skill);
        int EditSkill(Skill skill);
        int DeleteSkill(String skillname);

    }
}
