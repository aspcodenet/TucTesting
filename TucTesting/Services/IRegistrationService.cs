﻿namespace TucTesting.Services;

public interface IRegistrationService
{
    public enum RegistrationStatus
    {
        Ok,
        WrongEmailDomain,
        AlreadyRegistered,
        TooManyRegistrationsToday
    }

    RegistrationStatus RegisterUser(string email);
}