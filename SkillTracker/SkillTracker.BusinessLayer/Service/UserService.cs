using MongoDB.Driver;
using SkillTracker.BusinessLayer.Interface;
using SkillTracker.DataLayer;
using SkillTracker.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SkillTracker.BusinessLayer.Service
{
    public class UserService : IUserService
    {
        private readonly IMongoDBContext _mongoDBContext;
        private readonly IMongoCollection<User> _mongoCollection;

        public UserService(IMongoDBContext mongoDBContext)
        {
            _mongoDBContext = mongoDBContext;
            _mongoCollection = _mongoDBContext.GetCollection<User>(typeof(User).Name);
         
        }

        //Save new user into database
        public string CreateNewUser(User user)
        {
            //MongoDB Logic to save user document into database
            try
            {
              var result =  ValidateUserExist(user);
                if(result == string.Empty)
                {
                    _mongoCollection.InsertOne(user);
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
        //Save new user into database
        public string ValidateUserExist(User user)
        {
            //MongoDB Logic to save user document into database
            try
            {
                string result = string.Empty;
                var firstNameCriteria = Builders<User>.Filter.Eq("FirstName", user.FirstName);
               var emailCriteria = Builders<User>.Filter.Eq("Email", user.Email);
                var mobileCriteria = Builders<User>.Filter.Eq("Mobile", user.Mobile);

                var filterCriteria = Builders<User>.Filter.And(firstNameCriteria, emailCriteria,mobileCriteria);
                var userFind = _mongoCollection.Find(filterCriteria).SingleOrDefault();
                if(userFind !=null)
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

        //delete user details from database
        public int RemoveUser(string firstname, string lastname)
        {
            //MongoDB Logic to delete user document into database
            try
            {
                int count = 0;
                var firstNameCriteria = Builders<User>.Filter.Eq("FirstName", firstname);
                var lastNameCriteria = Builders<User>.Filter.Eq("LastName", lastname);

                var filterCriteria = Builders<User>.Filter.And(firstNameCriteria, lastNameCriteria);
                var deleteResult = _mongoCollection.DeleteOne(filterCriteria);
                

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

        //update user details into database
        public int UpdateUser(User user)
        {
            //MongoDB Logic to update user document into database
            try
            {
                int count = 0;
                var firstNameCriteria = Builders<User>.Filter.Eq("FirstName", user.FirstName);
                var lastNameCriteria = Builders<User>.Filter.Eq("LastName", user.LastName);

                var filterCriteria = Builders<User>.Filter.And(firstNameCriteria, lastNameCriteria);

                var updateElements = Builders<User>.Update.Set("Email", user.Email).Set("Mobile", user.Mobile).Set("MapSkills", user.MapSkills);

                var updateResult = _mongoCollection.UpdateOne(filterCriteria, updateElements, null);
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
    }
}
