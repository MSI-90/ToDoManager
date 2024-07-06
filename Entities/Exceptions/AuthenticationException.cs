namespace Domain.Exceptions;

public abstract class AuthenticationException : Exception
{
    protected AuthenticationException(string message) : base(message)
    {
    }
}
