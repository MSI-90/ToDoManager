﻿using System.ComponentModel.DataAnnotations;

namespace Entities.Models;

public class Category
{
    public Guid Id { get; set; }

    [Required]
    [MinLength(5, ErrorMessage = "Минимальное число символов для наименования категории - 5.")]
    [StringLength(100, ErrorMessage = "Максимальное число символов для наименования категории - 100.")]
    public string Title { get; set; } = string.Empty;

    [StringLength(200, ErrorMessage = "Максимальная число символов для поля описание категории - 200")]
    public string? Description { get; set; }
    public ICollection<TaskItem>? Tasks { get; set; }
}
