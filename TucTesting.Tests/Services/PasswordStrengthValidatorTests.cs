using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Utilities;
using TucTesting.Services;
/*
 Utveckla en PasswordStrengthValidator
Regler:
Lösenordet måste vara minst 10 tecken
Lösenordet måste innehålla minst en stor bokstav 
Lösenordet måste innehålla minst en liten bokstav
Lösenordet måste innehålla minst en siffra
Lösenordet måste innehålla minst en specal character
Lösenordet får inte innehålla texten password, secret, lösen

PasswordResult Validate(string password)
Ex returnera en enum

 *
 */

namespace TucTesting.Tests.Services
{
    [TestClass]
    public class PasswordStrengthValidatorTests
    {
        private readonly PasswordStrengthValidator sut;

        public PasswordStrengthValidatorTests()
        {
            sut = new PasswordStrengthValidator();
        }

        [TestMethod]
        public void When_passing_no_capital_letter_should_return_error()
        {
            var password = "1a34wb78a9";

            var result = sut.Validate(password);

            Assert.AreEqual(PasswordStrengthValidator.PasswordValidationResult.NoCapitalLetter, result);
        }


        [TestMethod]
        public void When_passing_less_than_10_characters_should_return_error()
        {
            var password = "123456789";

            var result = sut.Validate(password);

            Assert.AreEqual( PasswordStrengthValidator.PasswordValidationResult.PasswordTooShort, result );
        }
    }
}
