﻿using Domain.Entities;
using Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

[Table("tasks")]
public class TaskItem
{
    [Column("task_id")]
    public Guid Id { get; set; }

    [Column("task_title")]
    [Required(ErrorMessage = "Необходимо указать название задачи.")]
    [MinLength(5, ErrorMessage = "Минимальное число символов для наименования задачи - 5.")]
    [StringLength(100, ErrorMessage = "Максимальное число символов для наименования задачи - 100.")]
    public string Title { get; set; } = string.Empty;

    [Column("description")]
    [StringLength(200, ErrorMessage = "Максимальная число символов для поля описание задачи - 200")]
    public string? Description { get; set; }

    [Column("priority")]
    public Priority PriorityTask { get; set; }

    public bool IsCancelled { get; set; } = false;

    [Column("creation_date")]
    [Required]
    public DateTime CreatedAt { get; set; }

    [Column("expiration_date")]
    [Required]
    public DateTime ExpirationDate { get; set; }

    [Column("category_id")]
    [ForeignKey(nameof(Category))]
    public Guid? CategoryId { get; set; }
    public Category? Category { get; set; }

    [Column("user_id")]
    [ForeignKey(nameof(User))]
    public Guid UserId { get; set; }
    public ICollection<User> User { get; set; } = null!;
}
