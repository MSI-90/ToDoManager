﻿using Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

[Table("categories")]
public class Category
{
    [Column("category_id")]
    public Guid Id { get; set; }

    [Column("category_title")]
    [Required]
    [MinLength(5, ErrorMessage = "Минимальное число символов для наименования категории - 5.")]
    [StringLength(100, ErrorMessage = "Максимальное число символов для наименования категории - 100.")]
    public string Title { get; set; } = string.Empty;

    [Column("description")]
    [StringLength(200, ErrorMessage = "Максимальная число символов для поля описание категории - 200")]
    public string? Description { get; set; }

    [ForeignKey(nameof(User))]
    public Guid Userid { get; set; }
}
