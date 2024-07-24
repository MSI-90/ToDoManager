namespace Domain;

public static class Messages
{
    public const string DontDto = "Не указаны обязательные данные для заполнения";
    public const string PasswordDontValid = "Пароль неверный";
    public const string EmailIsAlreadyExist = "Уже имеется пользователь с указаным E-mail адресом.";
    public const string RegError = "Ошибка на этапе регистрации пользователя";
    public const string InvalidAuthData = "Аутентификация не удалась. Неверный email адрес или пароль.";
    public const string WrongAccessToken = "Неверный токен";
    public const string TaskItemNotFound = "Нет задачи по указанным данным.";
}
