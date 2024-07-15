using Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects;

public record TaskItemForCreationWithCategoryDto
{
    [Required(ErrorMessage = "Необходимо указать название задачи.")]
    [MinLength(5, ErrorMessage = "Минимальное число символов для наименования задачи - 5.")]
    [StringLength(100, ErrorMessage = "Максимальное число символов для наименования задачи - 100.")]
    public string Title { get; init; } = string.Empty;

    [StringLength(200, ErrorMessage = "Максимальная число символов для поля описание задачи - 200")]
    public string? Description { get; init; }
    public Priority PriorityTask { get; init; }

    [Required]
    public DateTime ExpirationDate { get; init; }
    public CategoryForCreationDto? Category { get; init; }
}
