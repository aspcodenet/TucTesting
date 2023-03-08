﻿namespace TucTesting.Services;

public class RegistrationService : IRegistrationService
{
    private readonly IUserRegistrationRepository _userRegistrationRepository;
    private readonly IEmailService _emailService;

    public RegistrationService(IUserRegistrationRepository userRegistrationRepository,
        IEmailService emailService)
    {
        _userRegistrationRepository = userRegistrationRepository;
        _emailService = emailService;
    }


    public IRegistrationService.RegistrationStatus RegisterUser(string email)
    {
        if (!VerifyEmailDomain(email))
            return IRegistrationService.RegistrationStatus.WrongEmailDomain;

        if (UserExists(email))
            return IRegistrationService.RegistrationStatus.AlreadyRegistered;

        if (GetNumberOfRegistrationsToday() >= 10)
            return IRegistrationService.RegistrationStatus.TooManyRegistrationsToday;

        SaveUser(email);
        SendWelcomeEmailToUser(email);

        return IRegistrationService.RegistrationStatus.Ok;
    }

    private void SendWelcomeEmailToUser(string email)
    {
        _emailService.SendEmail(email);
    }

    private void SaveUser(string email)
    {
        _userRegistrationRepository.CreateNew(email);
    }

    private int GetNumberOfRegistrationsToday()
    {
        return 1;
    }

    private bool UserExists(string email)
    {
        return _userRegistrationRepository.Get(email) != null;
    }

    private bool VerifyEmailDomain(string email)
    {
        return (email.ToLower().EndsWith("@hej.se") || email.ToLower().EndsWith("@hej.com"));
    }
}