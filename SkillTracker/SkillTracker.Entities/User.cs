using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillTracker.Entities
{
   public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String UserId { get; set; }

        [BsonElement("First Name")]
        [BsonRequired]
        public String FirstName { get; set; }

        [BsonElement("Lastl Name")]
        [BsonRequired]
        public String LastName { get; set; }

        [BsonElement("Email")]
        [BsonRequired]
        public String Email { get; set; }

        [BsonElement("Mobile Number")]
        [BsonRequired]
        public long Mobile { get; set; }

        [BsonElement("Map Skill ")]
        [BsonRequired]
        public int MapSkills { get; set; }
    }
}
