using Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class TaskItem
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Необходимо указать название задачи.")]
    [MinLength(5, ErrorMessage = "Минимальное число символов для наименования задачи - 5.")]
    [StringLength(100, ErrorMessage = "Максимальное число символов для наименования задачи - 100.")]
    public string Title { get; set; } = string.Empty;

    [StringLength(200, ErrorMessage = "Максимальная число символов для поля описание задачи - 200")]
    public string? Description { get; set; }
    public Priority PriorityTask { get; set; }
    
    [ForeignKey(nameof(Category))]
    public Guid CategoryId { get; set; }
    public Category? Category { get; set; }
}
