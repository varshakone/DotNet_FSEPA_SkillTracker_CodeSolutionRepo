using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillTracker.Entities
{
  public class Skill
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String SkillId { get; set; }

        [BsonElement("Skill Name")]
        [BsonRequired]
        public String SkillName { get; set; }

        [BsonElement("Skill Leve;")]
        [BsonRequired]
        public SkillLevel SkillLevel { get; set; }

        [BsonElement("Skill Category")]
        [BsonRequired]
        public SkillCategory SkillCategory { get; set; }

        [BsonRequired]
        [BsonElement("Skill Type")]
        public SkillType SkillType { get; set; }

        [BsonRequired]
        [BsonElement("Remark")]
       
        public String Remark { get; set; }

        [BsonRequired]
        [BsonElement("Skill Total Experiance")]
        public int SkillTotalExperiance { get; set; }
    }
}
