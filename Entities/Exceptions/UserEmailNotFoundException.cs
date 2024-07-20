namespace Domain.Exceptions;

public sealed class UserEmailNotFoundException : NotFoundException
{
    public UserEmailNotFoundException(string email) : base($"Не можем найти электронный адрес пользователя - {email}, проверьте данные.")
    {
    }
}
