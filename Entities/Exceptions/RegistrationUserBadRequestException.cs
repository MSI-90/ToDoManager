namespace Domain.Exceptions;

public sealed class RegistrationUserBadRequestException : BadRequestException
{
    public RegistrationUserBadRequestException(string message) : base (message)
    {
    }
}
