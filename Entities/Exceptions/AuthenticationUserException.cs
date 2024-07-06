namespace Domain.Exceptions;

public abstract class AuthenticationUserException : Exception
{
    protected AuthenticationUserException(string message) : base(message)
    {
    }
}
