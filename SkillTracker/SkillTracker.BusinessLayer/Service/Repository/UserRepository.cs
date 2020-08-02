using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SkillTracker.DataLayer;
using SkillTracker.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SkillTracker.BusinessLayer.Service.Repository
{

    public class UserRepository : IUserRepository
    {
        private readonly IMongoDBContext _mongoDBContext;
        private readonly IMongoCollection<User> _mongoCollection;

        public UserRepository(IMongoDBContext mongoDBContext)
        {
            _mongoDBContext = mongoDBContext;
            _mongoCollection = _mongoDBContext.GetCollection<User>(typeof(User).Name);

        }
        public UserRepository()
        {
            //MongoSettings settings = new MongoSettings
            //{
            //    Connection = "mongodb://localhost:27017",
            //    DatabaseName = "SkillTrackerDB"
            //};
            //IOptions<MongoSettings> options;
            //_mongoDBContext = new MongoDBContext();
            //_mongoCollection = _mongoDBContext.GetCollection<User>(typeof(User).Name);

        }

        /// <summary>
        /// Save new user into database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>

        public async Task<string> CreateNewUser(User user)
        {
            //MongoDB Logic to save user document into database
            try
            {
                var result = ValidateUserExist(user);
                if (result == string.Empty)
                {
                    await _mongoCollection.InsertOneAsync(user);
                    return "New User Register";
                }
                else
                {
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Validate user already exist before Saving new user into database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        
        public string ValidateUserExist(User user)
        {
            //MongoDB Logic to save user document into database
            try
            {
                string result = string.Empty;
                var firstNameCriteria = Builders<User>.Filter.Eq("FirstName", user.FirstName);
                var emailCriteria = Builders<User>.Filter.Eq("Email", user.Email);
                var mobileCriteria = Builders<User>.Filter.Eq("Mobile", user.Mobile);

                var filterCriteria = Builders<User>.Filter.And(firstNameCriteria, emailCriteria, mobileCriteria);
                var userFind = _mongoCollection.Find(filterCriteria).SingleOrDefault();
                if (userFind != null)
                {
                    result = "User Exist";
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// delete user details from database
        /// </summary>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <returns></returns>
        
        public async Task<int> RemoveUser(string firstname, string lastname)
        {
            //MongoDB Logic to delete user document into database
            try
            {
                int count = 0;
                var firstNameCriteria = Builders<User>.Filter.Eq("FirstName", firstname);
                var lastNameCriteria = Builders<User>.Filter.Eq("LastName", lastname);

                var filterCriteria = Builders<User>.Filter.And(firstNameCriteria, lastNameCriteria);
                var deleteResult =await _mongoCollection.DeleteOneAsync(filterCriteria);


                if (deleteResult.IsAcknowledged)
                {
                    count = (int)deleteResult.DeletedCount;
                }
                return count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// update user details into database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        
        public async Task<int> UpdateUser(User user)
        {
            //MongoDB Logic to update user document into database
            try
            {
                int count = 0;
                var firstNameCriteria = Builders<User>.Filter.Eq("FirstName", user.FirstName);
                var lastNameCriteria = Builders<User>.Filter.Eq("LastName", user.LastName);

                var filterCriteria = Builders<User>.Filter.And(firstNameCriteria, lastNameCriteria);

                var updateElements = Builders<User>.Update.Set("Email", user.Email).Set("Mobile", user.Mobile).Set("MapSkills", user.MapSkills);

                var updateResult =await _mongoCollection.UpdateOneAsync(filterCriteria, updateElements, null);
                if (updateResult.IsAcknowledged)
                {
                    count = (int)updateResult.ModifiedCount;
                }
                return count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// return list of all users 
        /// </summary>
        /// <returns></returns>
        
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            //MongoDB Logic to retrieve all users from database
            try
            {
                var usersList =await _mongoCollection.FindAsync(FilterDefinition<User>.Empty).Result.ToListAsync();
                return usersList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Search user by it's email
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        
        public async Task<User> SearchUserByEmail(string Email)
        {
            // MongoDB Logic to search user by email from database
            try
            {
                var filterCriteria = Builders<User>.Filter.Eq("Email", Email);
                var user =await _mongoCollection.FindAsync(filterCriteria).Result.SingleOrDefaultAsync();
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Search user by it's first name
        /// </summary>
        /// <param name="firstname"></param>
        /// <returns></returns>
        
        public async Task<User> SearchUserByFirstName(string firstname)
        {
            // MongoDB Logic to search user by firstname from database
            try
            {
                var filterCriteria = Builders<User>.Filter.Eq("FirstName", firstname);
                var user =await _mongoCollection.FindAsync(filterCriteria).Result.SingleOrDefaultAsync();
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Search user by it's mobile number
        public async Task<User> SearchUserByMobile(long mobilenumber)
        {
            //MongoDB Logic to search user by mobilenumber from database
            try
            {
                var filterCriteria = Builders<User>.Filter.Eq("Mobile", mobilenumber);
                var user =await _mongoCollection.FindAsync(filterCriteria).Result.SingleOrDefaultAsync();
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Search user by it's skill range between start value and end value
        /// </summary>
        /// <param name="startvalue"></param>
        /// <param name="endvalue"></param>
        /// <returns></returns>
       
        public async Task<IEnumerable<User>> SearchUserBySkillRange(int startvalue,int endvalue)
        {
            // MongoDB Logic to search user by Map Skill from database
            try
            {
                var filterCriteria = Builders<User>.Filter.Eq("MapSkills", startvalue);
                var user =await _mongoCollection.FindAsync(filterCriteria).Result.ToListAsync();
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
