using TucTesting.Models;

namespace TucTesting.Services;

public interface IUserRegistrationRepository
{
    UserRegistration Get(string email);
    void CreateNew(string email);
}