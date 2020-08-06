using Microsoft.Extensions.Configuration;
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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xunit;

namespace SkillTracker.Tests.TestCases
{

    [CollectionDefinition("parallel", DisableParallelization = false)]
    public   class BoundaryTest
    {
        // private references
        private User _user;
        IConfigurationRoot config;
        private Skill _skill;
        private IMongoDBContext context;
        private ISkillService _skillService;
        private IUserService _userService;
        private MongoDBUtility MongoDBUtility;
        private readonly IUserRepository _userRepository;
        private readonly ISkillRepository _skillRepository;


        static FileUtility fileUtility;
        String testResult;

        /// <summary>
        /// 
        /// </summary>
        public BoundaryTest()
        {
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

                FirstName = "Dnyati",
                LastName = "Dube",
                Email = "dnyati@gmail.com",
                Mobile = 9685744263,
            };

            MongoDBUtility = new MongoDBUtility();
            context = MongoDBUtility.MongoDBContext;
            _userRepository = new UserRepository(context);
            _skillRepository = new SkillRepository(context);

            _userService = new UserService(_userRepository);
            _skillService = new SkillService(_skillRepository);
            config = new ConfigurationBuilder().AddJsonFile("appsettings.test.json").Build();
        }

        /// <summary>
        /// Static constructor to create text file to write test result
        /// </summary>
        static BoundaryTest()
        {
            fileUtility = new FileUtility
            {
                FilePath = "../../../../output_boundary_revised.txt"
            };
            fileUtility.CreateTextFile();
        }



        // Test methods for User Service
        /// <summary>
        /// Validate Email Id
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task BoundaryTestFor_ValidEmail()
        {
            try
            {
                bool isEmail = false;
                //_userRepository.Setup(repo => repo.CreateNewUser(_user)).ReturnsAsync(_user);
              
                if (_user.Email != "")
                {
                    Regex regex = new Regex(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,}$");
                     isEmail = regex.IsMatch(_user.Email);
                    if (isEmail == true)
                    {
                        var result =  _userService.CreateNewUser(_user);
                        testResult = "BoundaryTestFor_ValidEmail=" + "True";
                        fileUtility.WriteTestCaseResuItInText(testResult);
                        // Write test case result in xml file
                        if (config["env"] == "development")
                        {
                            cases newcase = new cases
                            {
                                TestCaseType = "Boundary",
                                Name = "TestFor_ValidEmail",
                                expectedOutput = "True",
                                weight = 5,
                                mandatory = "True",
                                desc = "expecting to create new user after validating email Id"
                            };
                            await fileUtility.WriteTestCaseResuItInXML(newcase);
                        }
                    }
                }
                else
                {
                    Assert.True(isEmail);
                }
            }
            catch (Exception exception)
            {
                var res = exception.Message;
                testResult = "BoundaryTestFor_ValidEmail=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);
                // Write test case result in xml file
                if (config["env"] == "development")
                {
                    cases newcase = new cases
                    {
                        TestCaseType = "Boundary",
                        Name = "TestFor_ValidEmail",
                        expectedOutput = "False",
                        weight = 1,
                        mandatory = "False",
                        desc = "expecting to create new user after validating email Id but fail"
                    };
                    await fileUtility.WriteTestCaseResuItInXML(newcase);
                }
            }
        }

        /// <summary>
        /// Validate Mobile number length
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task BoundaryTestFor_ValidMobileNumberLength()
        {
            try
            {
                bool isMobile = false;
             if (_user.Mobile != 0)
                {
                    if (_user.Mobile.ToString().Length == 10)
                    {
                        isMobile = true ;
                     }
                    if (isMobile == true)
                    {
                        var result = _userService.CreateNewUser(_user);
                        testResult = "BoundaryTestFor_ValidMobileNumberLength=" + "True";
                        fileUtility.WriteTestCaseResuItInText(testResult);
                        // Write test case result in xml file
                        if (config["env"] == "development")
                        {
                            cases newcase = new cases
                            {
                                TestCaseType = "Boundary",
                                Name = "TestFor_ValidMobileNumberLength",
                                expectedOutput = "True",
                                weight = 5,
                                mandatory = "True",
                                desc = "expecting to create new user after validating mobile number length as 10"
                            };
                            await fileUtility.WriteTestCaseResuItInXML(newcase);
                        }
                    }
                }
                else
                {
                    Assert.True(isMobile);
                }
            }
            catch (Exception exception)
            {
                var res = exception.Message;
                testResult = "BoundaryTestFor_ValidMobileNumberLength=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);
                // Write test case result in xml file
                if (config["env"] == "development")
                {
                    cases newcase = new cases
                    {
                        TestCaseType = "Boundary",
                        Name = "TestFor_ValidMobileNumberLength",
                        expectedOutput = "False",
                        weight = 1,
                        mandatory = "False",
                        desc = "expecting to create new user after validating mobile number length as 10 but fail"
                    };
                    await fileUtility.WriteTestCaseResuItInXML(newcase);
                }
            }
        }


        /// <summary>
        /// Validate First name and last name 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task BoundaryTestFor_ValidFirstAndLastName()
        {
            try
            {
                bool isFirstNameValid = true;
                bool isLastNameValid = true;
                
                if (_user.FirstName != "" && _user.LastName != "")
                {
                    long f;
                    long l;
                    isFirstNameValid = long.TryParse(_user.FirstName, out f);
                    isLastNameValid = long.TryParse(_user.LastName, out l);
                    if (isFirstNameValid == false && isLastNameValid == false)
                    {
                         var result = _userService.CreateNewUser(_user);
                        testResult = "BoundaryTestFor_ValidFirstAndLastName=" + "True";
                        fileUtility.WriteTestCaseResuItInText(testResult);
                        // Write test case result in xml file
                        if (config["env"] == "development")
                        {
                            cases newcase = new cases
                            {
                                TestCaseType = "Boundary",
                                Name = "TestFor_ValidFirstAndLastName",
                                expectedOutput = "True",
                                weight = 5,
                                mandatory = "True",
                                desc = "expecting to create new user after validating firstname and lastname as non-numeric only"
                            };
                            await fileUtility.WriteTestCaseResuItInXML(newcase);
                        }
                    }
                }
                else
                {
                    Assert.False(isFirstNameValid);
                    Assert.False(isLastNameValid);
                }
            }
            catch (Exception exception)
            {
                var res = exception.Message;
                testResult = "BoundaryTestFor_ValidFirstAndLastName=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);
                // Write test case result in xml file
                if (config["env"] == "development")
                {
                    cases newcase = new cases
                    {
                        TestCaseType = "Boundary",
                        expectedOutput = "False",
                        Name = "TestFor_ValidFirstAndLastName",
                        weight = 1,
                        mandatory = "False",
                        desc = "expecting to create new user after validating firstname and lastname as non-numeric only but fail"
                    };
                    await fileUtility.WriteTestCaseResuItInXML(newcase);
                }
            }
        }


        //Test Methods for Skill Service
        [Fact]
        public async Task BoundaryTestFor_ValidSkillName()
        {
            try
            {
                bool isSkillNameValid = true;
             
                
                if (_skill.SkillName != "" )
                {
                    long f;
                  isSkillNameValid = long.TryParse(_skill.SkillName, out f);
                  
                    if (isSkillNameValid == false )
                    {
                        var result = _skillService.AddNewSkill(_skill);
                        testResult = "BoundaryTestFor_ValidSkillName=" + "True";
                        fileUtility.WriteTestCaseResuItInText(testResult);
                        // Write test case result in xml file
                        if (config["env"] == "development")
                        {
                            cases newcase = new cases
                            {
                                TestCaseType = "Boundary",
                                Name = "TestFor_ValidSkillName",
                                expectedOutput = "True",
                                weight = 5,
                                mandatory = "True",
                                desc = "expecting to create new skill after validating skill name as non-numeric only"
                            };
                            await fileUtility.WriteTestCaseResuItInXML(newcase);
                        }
                    }
                }
                else
                {
                    Assert.False(isSkillNameValid);
                    
                }
            }
            catch (Exception exception)
            {
                var res = exception.Message;
                testResult = "BoundaryTestFor_ValidSkillName=" + "False";
                fileUtility.WriteTestCaseResuItInText(testResult);
                // Write test case result in xml file
                if (config["env"] == "development")
                {
                    cases newcase = new cases
                    {
                        TestCaseType = "Boundary",
                        Name = "TestFor_ValidSkillName",
                        expectedOutput = "False",
                        weight = 1,
                        mandatory = "False",
                        desc = "expecting to create new skill after validating skill name as non-numeric only but fail"
                    };
                    await fileUtility.WriteTestCaseResuItInXML(newcase);
                }
            }
        }


    }


}
