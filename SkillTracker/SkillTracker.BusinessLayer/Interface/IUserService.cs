using SkillTracker.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SkillTracker.BusinessLayer.Interface
{
  public  interface IUserService
    {
        Task<String> CreateNewUser(User user);
        Task<int> UpdateUser(User user);
        Task<int> RemoveUser(String firstname, String lastname);
       Task<IEnumerable<User>> GetAllUsers();
        Task<User> SearchUserByFirstName(String firstname);
        Task<User> SearchUserByEmail(String Email);
        Task<User> SearchUserByMobile(long mobilenumber);
        Task<IEnumerable<User>> SearchUserBySkillRange(int startvalue, int endvalue);
    }
}
