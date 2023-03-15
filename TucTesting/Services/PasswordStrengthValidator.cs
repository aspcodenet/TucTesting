using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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
namespace TucTesting.Services
{
    public class PasswordStrengthValidator
    {
        public enum PasswordValidationResult
        {
            Ok,
            PasswordTooShort,
            NoCapitalLetter
        }

        public PasswordValidationResult Validate(string password)
        {
            if (password.Length < 10) return PasswordValidationResult.PasswordTooShort;
            
            bool foundCapital = false;
            foreach(char ch in password)
                if (char.IsUpper(ch))
                    foundCapital = true;
            if (!foundCapital) return PasswordValidationResult.NoCapitalLetter;
            
            return PasswordValidationResult.Ok;
        }
    }


}
