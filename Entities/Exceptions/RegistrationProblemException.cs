namespace Domain.Exceptions;

public sealed class RegistrationProblemException : AuthenticationUserException
{
    public RegistrationProblemException(string message) : base(message)
    {
    }
}
