namespace Domain.Exceptions;

public sealed class RegistrationProblemException : AuthenticationException
{
    public RegistrationProblemException(string message) : base(message)
    {
    }
}
