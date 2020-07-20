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
    public class SkillService : ISkillService
    {

        private readonly IMongoDBContext _mongoDBContext;
        private readonly IMongoCollection<Skill> _mongoCollection;

        public SkillService(IMongoDBContext mongoDBContext)
        {
            _mongoDBContext = mongoDBContext;
            _mongoCollection = _mongoDBContext.GetCollection<Skill>(typeof(Skill).Name);
        }

        // Save new skill upgarded by full stack engineer into database
        public string AddNewSkill(Skill skill)
        {
            //MongoDB Logic to save Skill document into database
            try
            {
               _mongoCollection.InsertOne(skill);
                return "New Skill Added";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // delete skill of full stack engineer from database
        public int DeleteSkill(string skillname)
        {
            //MongoDB Logic to delete Skill document into database
            try
            {
                int count =0;
                var filterCriteria = Builders<Skill>.Filter.Eq("SkillName", skillname);
              var deleteResult =  _mongoCollection.DeleteOne(filterCriteria);
                if(deleteResult.IsAcknowledged)
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
        // update skill upgarded by full stack engineer from database
        public int EditSkill(Skill skill)
        {
            //MongoDB Logic to update Skill document into database
            try
            {
                int count = 0;
                var filterCriteria = Builders<Skill>.Filter.Eq("SkillName", skill.SkillName);
               
                var updateElements = Builders<Skill>.Update.Set("SkillLevel", skill.SkillLevel).Set("SkillType", skill.SkillType).Set("SkillTotalExperiance", skill.SkillTotalExperiance);

                var updateResult =  _mongoCollection.UpdateOne(filterCriteria,updateElements,null);
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
