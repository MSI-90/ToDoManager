using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects;

public record UserForAutheticationDto
{
    [Required(ErrorMessage = "E-mail обязателен")]
    [EmailAddress(ErrorMessage = "Проверьте корректность ввода e-mail адреса")]
    [StringLength(50, ErrorMessage = "Максимальная длина для e-mail 50 символов")]
    public string Email {  get; init; } = string.Empty;

    [Required(ErrorMessage = "Необходимо указать пароль.")]
    [DataType(DataType.Password)]
    [MinLength(8, ErrorMessage = "Минимальная длина для пароля 8 символов.")]
    [MaxLength(20, ErrorMessage = "Достаточно 20 символов.")]
    public string Password { get; init; } = string.Empty;
}
