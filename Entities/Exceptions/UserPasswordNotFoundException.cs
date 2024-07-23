namespace Domain.Exceptions;

public sealed class UserPasswordNotFoundException : NotFoundException
{
    public UserPasswordNotFoundException() : base(Messages.PasswordDontValid)
    {
    }
}
