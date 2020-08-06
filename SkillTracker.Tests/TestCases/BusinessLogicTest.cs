using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Moq;
using SkillTracker.BusinessLayer.Interface;
using SkillTracker.BusinessLayer.Service;
using SkillTracker.BusinessLayer.Service.Repository;
using SkillTracker.DataLayer;
using SkillTracker.Entities;
using SkillTracker.Tests.Utility;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SkillTracker.Tests.TestCases
{
  
    [Collection("parallel")]
    public  class BusinessLogicTest
    {
        // private references declaration
        private User _user;
        IConfigurationRoot config;
        private readonly IUserRepository _userRepository;
        private readonly ISkillRepository _skillRepository;
        
        private Skill _skill;
        private IMongoDBContext context;

        private ISkillService _skillService;
        private IUserService _userService;
        
        static FileUtility fileUtility;
        String testResult;



        public BusinessLogicTest()
        {
            MongoDBUtility mongoDBUtility = new MongoDBUtility();
            context = mongoDBUtility.MongoDBContext;

            _userRepository = new UserRepository(context);
            _skillRepository = new SkillRepository(context);

            _userService = new UserService(_userRepository);
            _skillService = new SkillService(_skillRepository);
            _skill = new Skill
            {
                SkillName = ".Net core 3.1",
                SkillCategory = SkillCategory.DotNet,
                SkillLevel = SkillLevel.Intermediate,
                SkillType = SkillType.Programming,
                SkillTotalExperiance = 1
            };

            _user = new User
            {

                FirstName = "anvi",
                LastName = "patil",
                Email = "anvi@gmail.com",
                Mobile = 1236548978,
                MapSkills = 2
            };
            config = new ConfigurationBuilder().AddJsonFile("appsettings.test.json").Build();
        }
        static BusinessLogicTest()
        {
            fileUtility = new FileUtility();
            fileUtility.FilePath = "../../../../output_business_revised.txt";
            fileUtility.CreateTextFile();
        }

        /// <summary>
        /// Test methods for Skill Service
        /// Test method to create new skill
        /// </summary>
        /// <returns></returns>
        [Fact]
     public async Task BusinessTestFor_AddNewSkill_Possitive()
        {
            try
            {
          
                
                var result =await _skillService.AddNewSkill(_skill);
                if (result == "New Skill Added")
                {
                    testResult = "BusinessTestFor_AddNewSkill_Possitive=" + "True";
                    fileUtility.WriteTestCaseResuItInText(testResult);
                    // Write test case result in xml file
                    if (config["env"] == "development")
                    {
                        cases newcase = new cases
                        {
                            TestCaseType = "Business",
                            Name = "BusinessTestFor_AddNewSkill_Possitive",
                            expectedOutput = "True",
                            weight = 5,
                            mandatory = "True",
                            desc = "allows to add new skill and return success message"
                        };
                        await fileUtility.WriteTestCaseResuItInXML(newcase);
                    }
                }
                else
                {
                    Assert.Equal("New Skill Added", result);
                }
            }
            catch (Exception exception)
            {
                var res = exception.Message;
                testResult = "BusinessTestFor_AddNewSkill_Possitive=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);
                // Write test case result in xml file
                if (config["env"] == "development")
                {
                    cases newcase = new cases
                    {
                        TestCaseType = "Business",
                        Name = "BusinessTestFor_AddNewSkill_Possitive",
                        expectedOutput = "False",
                        weight = 5,
                        mandatory = "False",
                        desc = "expected to add new skill and return success message but fail"
                    };
                    await fileUtility.WriteTestCaseResuItInXML(newcase);
                }
            }
        }

        /// <summary>
        /// test method to update skill
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task BusinessTestFor_EditSkill_Possitive()
        {
            try
            {

                 _skill.SkillLevel = SkillLevel.Expert;
                _skill.SkillTotalExperiance = 10;
                var result =await  _skillService.EditSkill(_skill);
                if (result == 1)
                {
                    testResult = "BusinessTestFor_EditSkill_Possitive=" + "True";
                    fileUtility.WriteTestCaseResuItInText(testResult);
                    // Write test case result in xml file
                    if (config["env"] == "development")
                    {
                        cases newcase = new cases
                        {
                            TestCaseType = "Business",
                            Name = "BusinessTestFor_EditSkill_Possitive",
                            expectedOutput = "True",
                            weight = 5,
                            mandatory = "True",
                            desc = "na"
                        };
                        await fileUtility.WriteTestCaseResuItInXML(newcase);
                    }
                }
                else
                {
                    Assert.Equal(1, result);
                }
            }
            catch (Exception exception)
            {
                var res = exception.Message;
                testResult = "BusinessTestFor_EditSkill_Possitive=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);
                // Write test case result in xml file
                if (config["env"] == "development")
                {
                    cases newcase = new cases
                    {
                        TestCaseType = "Business",
                        Name = "BusinessTestFor_EditSkill_Possitive",
                        expectedOutput = "False",
                        weight = 5,
                        mandatory = "False",
                        desc = "na"
                    };
                    await fileUtility.WriteTestCaseResuItInXML(newcase);
                }
            }
        }

        /// <summary>
        /// test method to delete skill
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task BusinessTestFor_DeleteSkill_Possitive()
        {
            try
            {

                
               var result =await _skillService.DeleteSkill(_skill.SkillName);
                if (result == 1)
                {
                    testResult = "BusinessTestFor_DeleteSkill_Possitive=" + "True";
                    fileUtility.WriteTestCaseResuItInText(testResult);
                    // Write test case result in xml file
                    if (config["env"] == "development")
                    {
                        cases newcase = new cases
                        {
                            TestCaseType = "Business",
                            Name = "BusinessTestFor_DeleteSkill_Possitive",
                            expectedOutput = "True",
                            weight = 5,
                            mandatory = "True",
                            desc = "na"
                        };
                        await fileUtility.WriteTestCaseResuItInXML(newcase);
                    }
                }
                else
                {
                    Assert.Equal(1, result);
                }
            }
            catch (Exception exception)
            {
                var res = exception.Message;
                testResult = "BusinessTestFor_DeleteSkill_Possitive=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);
                // Write test case result in xml file
                if (config["env"] == "development")
                {
                    cases newcase = new cases
                    {
                        TestCaseType = "Business",
                        Name = "BusinessTestFor_DeleteSkill_Possitive",
                        expectedOutput = "False",
                        weight = 5,
                        mandatory = "False",
                        desc = "na"
                    };
                    await fileUtility.WriteTestCaseResuItInXML(newcase);
                }
            }
        }

        
        /// <summary>
        /// Test Methods for User Service
        /// test method to create new user
        ///</summary>
        /// <returns></returns>

        [Fact]
        public async Task BusinessTestFor_CreateNewUser_Possitive()
        {
            try
            {
                fileUtility.ValidateUser(_user);
                var result =await _userService.CreateNewUser(_user);
                if (result == "New User Register")
                {
                    testResult = "BusinessTestFor_CreateNewUser_Possitive=" + "True";
                    fileUtility.WriteTestCaseResuItInText(testResult);
                    // Write test case result in xml file
                    if (config["env"] == "development")
                    {
                        cases newcase = new cases
                        {
                            TestCaseType = "Business",
                            Name = "BusinessTestFor_CreateNewUser_Possitive",
                            expectedOutput = "True",
                            weight = 5,
                            mandatory = "True",
                            desc = "allows to create new user and return success message"
                        };
                        await fileUtility.WriteTestCaseResuItInXML(newcase);
                    }
                }
                else
                {
                    Assert.Equal("New User Register", result);
                }
            }
            catch (Exception exception)
            {
                var res = exception.Message;
                testResult = "BusinessTestFor_CreateNewUser_Possitive=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);
                // Write test case result in xml file
                if (config["env"] == "development")
                {
                    cases newcase = new cases
                    {
                        TestCaseType = "Business",
                        Name = "BusinessTestFor_CreateNewUser_Possitive",
                        expectedOutput = "False",
                        weight = 5,
                        mandatory = "False",
                        desc = "allows to create new user and expecting success message but throw exception"
                    };
                    await fileUtility.WriteTestCaseResuItInXML(newcase);
                }
            }
        }

        /// <summary>
        /// test method to update user
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task BusinessTestFor_UpdateUser_Possitive()
        {
            try
            {
                User user = new User
                {
                    FirstName = "shashank",
                    LastName = "mishra",
                    Email = "shashank@gmail.com",
                    Mobile = 9960814103,
                    MapSkills = 3

                };
                fileUtility.TestData(user);

                user.Email = "Shashank.mishra@gmail.com";
                user.Mobile = 8874569874;
                user.MapSkills = 5;

               
                            
                var result =await  _userService.UpdateUser(user);
                if (result == 1)
                {
                    testResult = "BusinessTestFor_UpdateUser_Possitive=" + "True";
                    fileUtility.WriteTestCaseResuItInText(testResult);
                    // Write test case result in xml file
                    if (config["env"] == "development")
                    {
                        cases newcase = new cases
                        {
                            TestCaseType = "Business",
                            Name = "BusinessTestFor_UpdateUser_Possitive",
                            expectedOutput = "True",
                            weight = 5,
                            mandatory = "True",
                            desc = "allows to update existing user and expecting 1 "
                        };
                        await fileUtility.WriteTestCaseResuItInXML(newcase);
                    }
                    fileUtility.ValidateUser(user);
                }
                else
                {
                    Assert.Equal(1, result);
                }
            }
            catch (Exception exception)
            {
                var res = exception.Message;
                testResult = "BusinessTestFor_UpdateUser_Possitive=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);
                // Write test case result in xml file
                if (config["env"] == "development")
                {
                    cases newcase = new cases
                    {
                        TestCaseType = "Business",
                        Name = "BusinessTestFor_UpdateUser_Possitive",
                        expectedOutput = "False",
                        weight = 5,
                        mandatory = "False",
                        desc = "allows to update existing user and expecting 1 but throw exception"
                    };
                    await fileUtility.WriteTestCaseResuItInXML(newcase);
                }

            }
        }

        /// <summary>
        /// test method to delete user
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task BusinessTestFor_RemoveUser_Possitive()
        {
            try
            {
                User user = new User
                {
                    FirstName = "Anay",
                    LastName = "patil",
                    Email = "anay@gmail.com",
                    Mobile = 9968587456,
                    MapSkills = 3

                };
                fileUtility.TestData(user);
                
               
                var result =await _userService.RemoveUser(user.FirstName, user.LastName);
                if (result == 1)
                {
                    testResult = "BusinessTestFor_RemoveUser_Possitive=" + "True";
                    fileUtility.WriteTestCaseResuItInText(testResult);
                    // Write test case result in xml file
                    if (config["env"] == "development")
                    {
                        cases newcase = new cases
                        {
                            TestCaseType = "Business",
                            Name = "BusinessTestFor_RemoveUser_Possitive",
                            expectedOutput = "True",
                            weight = 5,
                            mandatory = "True",
                            desc = "allows to delete existing user and expecting 1 "
                        };
                        await fileUtility.WriteTestCaseResuItInXML(newcase);
                    }
                }
                else
                {
                    Assert.Equal(1, result);
                }
            }
            catch (Exception exception)
            {
                var res = exception.Message;
                testResult = "BusinessTestFor_RemoveUser_Possitive=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);
                // Write test case result in xml file
                if (config["env"] == "development")
                {
                    cases newcase = new cases
                    {
                        TestCaseType = "Business",
                        Name = "BusinessTestFor_RemoveUser_Possitive",
                        expectedOutput = "False",
                        weight = 1,
                        mandatory = "False",
                        desc = "allows to delete existing user and expecting 1 but throw exception"
                    };
                    await fileUtility.WriteTestCaseResuItInXML(newcase);
                }
            }
        }

        /// <summary>
        /// test method to retrieve all users
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task BusinessTestFor_AllUsers_Possitive()
        {
            try
            {
               
                   var result =await  _userService.GetAllUsers() as List<User>;
                if (result.Count > 0)
                {
                    testResult = "BusinessTestFor_AllUsers_Possitive=" + "True";
                    fileUtility.WriteTestCaseResuItInText(testResult);
                    // Write test case result in xml file
                    if (config["env"] == "development")
                    {
                        cases newcase = new cases
                        {
                            TestCaseType = "Business",
                            Name = "BusinessTestFor_AllUsers_Possitive",
                            expectedOutput = "True",
                            weight = 5,
                            mandatory = "True",
                            desc = "Shows list of users to admin user "
                        };
                        await fileUtility.WriteTestCaseResuItInXML(newcase);
                    }
                }
                else
                {
                    Assert.NotEmpty(result);
                }
            }
            catch (Exception exception)
            {
                var res = exception.Message;
                testResult = "BusinessTestFor_AllUsers_Possitive=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);
                // Write test case result in xml file
                if (config["env"] == "development")
                {
                    cases newcase = new cases
                    {
                        TestCaseType = "Business",
                        Name = "BusinessTestFor_AllUsers_Possitive",
                        expectedOutput = "False",
                        weight = 1,
                        mandatory = "False",
                        desc = "expecting  to shows list of users to admin user but fail"
                    };
                    await fileUtility.WriteTestCaseResuItInXML(newcase);
                }
            }
        }

        /// <summary>
        /// test method to search user by first name
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task BusinessTestFor_SearchUserByFirstName_Possitive()
        {
            try
            {
                
                 var result =await _userService.SearchUserByFirstName(_user.FirstName);
                if (result != null)
                {
                    testResult = "BusinessTestFor_SearchUserByFirstName_Possitive=" + "True";
                    fileUtility.WriteTestCaseResuItInText(testResult);
                    // Write test case result in xml file
                    if (config["env"] == "development")
                    {
                        cases newcase = new cases
                        {
                            TestCaseType = "Business",
                            Name = "BusinessTestFor_SearchUserByFirstName_Possitive",
                            expectedOutput = "True",
                            weight = 5,
                            mandatory = "True",
                            desc = "na "
                        };
                       await fileUtility.WriteTestCaseResuItInXML(newcase);
                    }
                }
                else
                {
                    Assert.Contains(_user.FirstName, result.FirstName);
                }
            }
            catch (Exception exception)
            {
                var res = exception.Message;
                testResult = "BusinessTestFor_SearchUserByFirstName_Possitive=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);
                // Write test case result in xml file
                if (config["env"] == "development")
                {
                    cases newcase = new cases
                    {
                        TestCaseType = "Business",
                        Name = "BusinessTestFor_SearchUserByFirstName_Possitive",
                        expectedOutput = "False",
                        weight = 1,
                        mandatory = "False",
                        desc = "na"
                    };
                    await fileUtility.WriteTestCaseResuItInXML(newcase);
                }
            }
        }

        /// <summary>
        /// test method to search user by email id
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task BusinessTestFor_SearchUserByEmail_Possitive()
        {
            try
            {
                
            
                var result =await _userService.SearchUserByEmail(_user.Email);
                if (result != null)
                {
                    testResult = "BusinessTestFor_SearchUserByEmail_Possitive=" + "True";
                    fileUtility.WriteTestCaseResuItInText(testResult);
                    // Write test case result in xml file
                    if (config["env"] == "development")
                    {
                        cases newcase = new cases
                        {
                            TestCaseType = "Business",
                            Name = "BusinessTestFor_SearchUserByEmail_Possitive",
                            expectedOutput = "True",
                            weight = 5,
                            mandatory = "True",
                            desc = "na "
                        };
                        await fileUtility.WriteTestCaseResuItInXML(newcase);
                    }
                }
                else
                {
                    Assert.Contains(_user.FirstName, result.FirstName);
                }
            }
            catch (Exception exception)
            {
                var res = exception.Message;
                testResult = "BusinessTestFor_SearchUserByEmail_Possitive=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);
                // Write test case result in xml file
                if (config["env"] == "development")
                {
                    cases newcase = new cases
                    {
                        TestCaseType = "Business",
                        Name = "BusinessTestFor_SearchUserByEmail_Possitive",
                        expectedOutput = "False",
                        weight = 1,
                        mandatory = "False",
                        desc = "na"
                    };
                    await fileUtility.WriteTestCaseResuItInXML(newcase);
                }
            }
        }

        /// <summary>
        /// test method to search user by mobile number
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task BusinessTestFor_SearchUserByMobileNumber_Possitive()
        {
            try
            {
              
                            
                var result =await _userService.SearchUserByMobile(_user.Mobile);
                if (result != null)
                {
                    testResult = "BusinessTestFor_SearchUserByMobileNumber_Possitive=" + "True";
                    fileUtility.WriteTestCaseResuItInText(testResult);
                    // Write test case result in xml file
                    if (config["env"] == "development")
                    {
                        cases newcase = new cases
                        {
                            TestCaseType = "Business",
                            Name = "BusinessTestFor_SearchUserByMobileNumber_Possitive",
                            expectedOutput = "True",
                            weight = 5,
                            mandatory = "True",
                            desc = "na "
                        };
                        await fileUtility.WriteTestCaseResuItInXML(newcase);
                    }
                }
                else
                {
                    Assert.Contains(_user.FirstName, result.FirstName);
                }
            }
            catch (Exception exception)
            {
                var res = exception.Message;
                testResult = "BusinessTestFor_SearchUserByMobileNumber_Possitive=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);
                // Write test case result in xml file
                if (config["env"] == "development")
                {
                    cases newcase = new cases
                    {
                        TestCaseType = "Business",
                        Name = "BusinessTestFor_SearchUserByMobileNumber_Possitive",
                        expectedOutput = "False",
                        weight = 1,
                        mandatory = "False",
                        desc = "na"
                    };
                    await fileUtility.WriteTestCaseResuItInXML(newcase);
                }
            }
        }

        /// <summary>
        /// test method to search user by it's skill range
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task BusinessTestFor_SearchUserBySkillRange_Possitive()
        {
            try
            {
               
                
                var result =await  _userService.SearchUserBySkillRange(2,2);
                if (result != null)
                {
                    testResult = "BusinessTestFor_SearchUserBySkillRange_Possitive=" + "True";
                    fileUtility.WriteTestCaseResuItInText(testResult);
                    // Write test case result in xml file
                    if (config["env"] == "development")
                    {
                        cases newcase = new cases
                        {
                            TestCaseType = "Business",
                            Name = "BusinessTestFor_SearchUserBySkillRange_Possitive",
                            expectedOutput = "True",
                            weight = 5,
                            mandatory = "True",
                            desc = "na "
                        };
                        await fileUtility.WriteTestCaseResuItInXML(newcase);
                    }
                }
                else
                {
                    Assert.NotEmpty( result);
                }
            }
            catch (Exception exception)
            {
                var res = exception.Message;
                testResult = "BusinessTestFor_SearchUserBySkillRange_Possitive=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);
                // Write test case result in xml file
                if (config["env"] == "development")
                {
                    cases newcase = new cases
                    {
                        TestCaseType = "Business",
                        Name = "BusinessTestFor_SearchUserBySkillRange_Possitive",
                        expectedOutput = "False",
                        weight = 1,
                        mandatory = "False",
                        desc = "na"
                    };
                    await fileUtility.WriteTestCaseResuItInXML(newcase);
                }
            }
        }
    }
}
