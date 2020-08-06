using MongoDB.Driver;
using SkillTracker.DataLayer;
using SkillTracker.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SkillTracker.BusinessLayer.Service.Repository
{
    public class SkillRepository : ISkillRepository
    {
        private readonly IMongoDBContext _mongoDBContext;
        private readonly IMongoCollection<Skill> _mongoCollection;

        public SkillRepository(IMongoDBContext mongoDBContext)
        {
            _mongoDBContext = mongoDBContext;
            _mongoCollection = _mongoDBContext.GetCollection<Skill>(typeof(Skill).Name);

        }

        public SkillRepository()
        {

        }
        /// <summary>
        /// Save skill document into database
        /// </summary>
        /// <param name="skill"></param>
        /// <returns></returns>
        public async Task<string> AddNewSkill(Skill skill)
        {
            //MongoDB Logic to save Skill document into database
            try
            {
               await _mongoCollection.InsertOneAsync(skill);
                return "New Skill Added";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Delete skill document from database
        /// </summary>
        /// <param name="skillname"></param>
        /// <returns></returns>
        public async Task<int> DeleteSkill(string skillname)
        {
            //MongoDB Logic to delete Skill document into database
            try
            {
                int count = 0;
                var filterCriteria = Builders<Skill>.Filter.Eq("SkillName", skillname);
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
        /// Update skill document into database
        /// </summary>
        /// <param name="skill"></param>
        /// <returns></returns>
        public async Task<int> EditSkill(Skill skill)
        {
            //MongoDB Logic to update Skill document into database
            try
            {
                int count = 0;
                var filterCriteria = Builders<Skill>.Filter.Eq("SkillName", skill.SkillName);

                var updateElements = Builders<Skill>.Update.Set("SkillLevel", skill.SkillLevel).Set("SkillType", skill.SkillType).Set("SkillTotalExperiance", skill.SkillTotalExperiance);

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
    }
}
