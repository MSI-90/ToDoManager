namespace Domain.Exceptions;

public sealed class RefreshTokenBadRequestException : BadRequestException
{
    public RefreshTokenBadRequestException() : base(Messages.WrongAccessToken)
    {
    }
}
