using Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects;

public record TaskItemForManipulationDto
{
    [Required(ErrorMessage = "Необходимо указать название задачи.")]
    [MinLength(5, ErrorMessage = "Минимальное число символов для наименования задачи - 5.")]
    [StringLength(100, ErrorMessage = "Максимальное число символов для наименования задачи - 100.")]
    public string TaskItemTitle { get; init; } = string.Empty;

    [StringLength(200, ErrorMessage = "Максимальная число символов для поля описание задачи - 200")]
    public string? TaskItemDescription { get; init; }
    public string TaskItemPriority { get; init; }
    public DateTime CreationDate { get; init; } = DateTime.UtcNow;

    [Required]
    public DateTime ExpiratinDate { get; init; }
}
