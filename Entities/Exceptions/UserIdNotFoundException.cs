namespace Domain.Exceptions;

public sealed class UserIdNotFoundException : NotFoundException
{
    public UserIdNotFoundException() : base($"Пользователь не зарегистрирован.")
    {
    }
}
