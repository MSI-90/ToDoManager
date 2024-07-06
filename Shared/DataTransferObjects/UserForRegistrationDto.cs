using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects;

public record UserForRegistrationDto
{
    [Required(ErrorMessage = "Имя пользователя обязательно")]
    [StringLength(50)]
    public string FirstName { get; init; } = string.Empty;

    [Required(ErrorMessage = "Фамилия обязательна")]
    [StringLength(50)]
    public string LastName { get; init; } = string.Empty;

    [Required(ErrorMessage = "E-mail обязателен.")]
    [EmailAddress(ErrorMessage = "Проверьте корректность ввода e-mail адреса")]
    [StringLength(50, ErrorMessage = "Максимальная длина для e-mail 50 символов")]
    public string Email { get; init; } = string.Empty;

    [Required(ErrorMessage = "Необходимо указать пароль.")]
    [DataType(DataType.Password)]
    [MinLength(8, ErrorMessage = "Минимальная длина для пароля 8 символов.")]
    [MaxLength(20, ErrorMessage = "Достаточно 20 символов.")]
    public string PasswordInput { get; init; } = string.Empty;

    [Compare(nameof(PasswordInput), ErrorMessage = "Проверьте данные.")]
    public string PasswordConfirmed {  get; init; } = string.Empty;
}
