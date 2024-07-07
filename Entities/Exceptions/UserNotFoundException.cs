namespace Domain.Exceptions;

public sealed class UserNotFoundException : NotFoundException
{
    public UserNotFoundException(string email) : base($"Не можем найти электронный адрес пользователя - {email}, проверьте данные.")
    {
    }
}
