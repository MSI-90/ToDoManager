namespace Domain.Exceptions;

internal sealed class AuthenticationException : Exception
{
    public AuthenticationException(string message) : base(message)
    {
    }
}
