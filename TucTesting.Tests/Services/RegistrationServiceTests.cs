using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using TucTesting.Models;
using TucTesting.Services;
using static TucTesting.Services.IRegistrationService;

namespace TucTesting.Tests.Services
{
    //public class FakeUserRepository : IUserRegistrationRepository
    //{
    //    public List<string> registeredEmails = new List<string>();
    //    public UserRegistration Get(string email)
    //    {
    //        //if (registeredEmails.Contains(email) == null) return null;
    //        //return new UserRegistration();

    //        return registeredEmails.Contains(email) ? new UserRegistration() : null;
    //    }
    //    public void CreateNew(string email)
    //    {
    //        registeredEmails.Add(email);
    //    }
    //}

    //public class FakeEmailService : IEmailService
    //{
    //    public bool MethodHasBeenCalled = false;
    //    public void SendEmail(string email)
    //    {
    //        MethodHasBeenCalled = true;
    //    }
    //}

    // Är personens webaddress med domän @hej.se eller @hej.com ? Annars fail
    [TestClass]
    public class RegistrationServiceTests
    {
        private RegistrationService sut;
        //private FakeUserRepository fakeUserRepository = new FakeUserRepository();
        //private FakeEmailService fakeEmailService = new FakeEmailService();
        private readonly Mock<IUserRegistrationRepository> userRepositoryMock;
        private readonly Mock<IEmailService> emailServiceMock;

        public RegistrationServiceTests()
        {
            userRepositoryMock = new Mock<IUserRegistrationRepository>();
            emailServiceMock = new Mock<IEmailService>();
            sut = new RegistrationService(userRepositoryMock.Object,
                emailServiceMock.Object);
        }

        [TestMethod]
        public void When_registration_ok_email_is_sent()
        {
            //ARRANGE
            var email = "stefan@hej.se";
            userRepositoryMock.Setup(u => u.Get(email)).Returns((UserRegistration)null);
            //ACT
            sut.RegisterUser(email);

            //ASSERT
            emailServiceMock.Verify(e=>e.SendEmail(email), Times.Once());

            //Assert.IsTrue(fakeEmailService.MethodHasBeenCalled);


        }

        [TestMethod]
        public void When_registration_ok_user_is_saved()
        {
            //ARRANGE
            var email = "stefan@hej.se";
            userRepositoryMock.Setup(u => u.Get(email)).Returns((UserRegistration)null);


            //ACT
            sut.RegisterUser(email);

            //ASSERT
            userRepositoryMock.Verify(u=>u.CreateNew(email), Times.Once());
            //Assert.IsTrue(fakeUserRepository.registeredEmails.Contains(email));
        }

        [TestMethod]
        public void When_registering_and_already_registered_should_fail()
        {
            // ARRANGE
            var userEmail = "stefan@hej.se";
            userRepositoryMock.Setup(u => u.Get(userEmail)).Returns(new UserRegistration());
            //fakeUserRepository.CreateNew(userEmail);
            
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
