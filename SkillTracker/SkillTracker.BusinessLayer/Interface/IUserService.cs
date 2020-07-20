using SkillTracker.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SkillTracker.BusinessLayer.Interface
{
  public  interface IUserService
    {
        String CreateNewUser(User user);
        int UpdateUser(User user);
        int RemoveUser(String firstname, String lastname);
        string ValidateUserExist(User user);
    }
}
