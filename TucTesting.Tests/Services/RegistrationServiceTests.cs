using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TucTesting.Services;

namespace TucTesting.Tests.Services
{
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
