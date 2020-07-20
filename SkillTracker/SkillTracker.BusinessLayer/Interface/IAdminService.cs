using SkillTracker.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SkillTracker.BusinessLayer.Interface
{
   public  interface IAdminService
    {
        IEnumerable<User> GetAllUsers();
        User SearchUserByFirstName(String firstname);
        User SearchUserByEmail(String Email);
        User SearchUserByMobile(long mobilenumber);
       IEnumerable<User> SearchUserBySkillRange(int startvalue);

    }
}
