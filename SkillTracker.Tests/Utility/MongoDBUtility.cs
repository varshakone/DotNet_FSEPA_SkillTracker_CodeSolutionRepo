using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Moq;
using SkillTracker.DataLayer;
using SkillTracker.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillTracker.Tests.Utility
{
  public   class MongoDBUtility
    {
        private Mock<IMongoCollection<Skill>> _mockCollectionSkill;
        private Mock<IMongoCollection<User>> _mockCollectionUser;
        private Mock<IMongoDBContext> _mockContext;
        private Mock<IOptions<MongoSettings>> _mockOptions;
        MongoSettings settings;
        MongoDBContext mongoDBcontext;
        public MongoDBUtility()
        {
            _mockContext = new Mock<IMongoDBContext>();
             _mockCollectionSkill = new Mock<IMongoCollection<Skill>>();
            _mockCollectionUser = new Mock<IMongoCollection<User>>();
            _mockOptions = new Mock<IOptions<MongoSettings>>();
            settings = new MongoSettings()
            {
                
                Connection = "mongodb://user:password@127.0.0.1:27017/guestbook",
            DatabaseName= "guestbook"
            };
            _mockOptions.Setup(s => s.Value).Returns(settings);
             mongoDBcontext = new MongoDBContext(_mockOptions.Object);
        }
         
        
        public Mock<IMongoCollection<Skill>> MockCollectionSkill { get => _mockCollectionSkill;  }
        public Mock<IMongoDBContext> MockContext { get => _mockContext; }
        public Mock<IOptions<MongoSettings>> MockOptions { get => _mockOptions; }
        public MongoSettings Settings { get => settings; }
        public MongoDBContext MongoDBContext { get => mongoDBcontext;  }
        public Mock<IMongoCollection<User>> MockCollectionUser { get => _mockCollectionUser;  }
    }
}
