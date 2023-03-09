using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TucTesting.Models;
using TucTesting.Services;
using static TucTesting.Services.IRegistrationService;

namespace TucTesting.Tests.Services
{
    public class FakeUserRepository : IUserRegistrationRepository
    {
        public List<string> registeredEmails = new List<string>();
        public UserRegistration Get(string email)
        {
            throw new NotImplementedException();
        }
        public void CreateNew(string email)
        {
            throw new NotImplementedException();
        }
    }

    // Är personens webaddress med domän @hej.se eller @hej.com ? Annars fail
    [TestClass]
    public class RegistrationServiceTests
    {
        private RegistrationService sut;

        public RegistrationServiceTests()
        {
            sut = new RegistrationService(null,null);
        }

        [TestMethod]
        public void When_registering_and_already_registered_should_fail()
        {
            // ARRANGE
            var userEmail = "stefan@hej.se";
            // Få den att redan vara regostrerad
            
            //ACT
            var result = sut.RegisterUser(userEmail);

            //ASSERT
            Assert.AreEqual(IRegistrationService.RegistrationStatus.AlreadyRegistered, result);
        } 

        [TestMethod]
        public void When_registering_using_invalid_email_should_fail()
        {
            // ARRANGE

            // ACT
            var result = sut.RegisterUser("aaa@aaa.se");

            //ASSERT
            Assert.AreEqual(IRegistrationService.RegistrationStatus.WrongEmailDomain, result);
        }
    }
}
