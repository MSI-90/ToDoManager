﻿using Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

[Table("usercategory")]
public class UserCategory
{
    [Column("user_id")]
    public string UserId { get; set; } = string.Empty;

    [Column("category_id")]
    public Guid? CategoryId { get; set; }

    public /*ICollection<User>*/ User User { get; set; } = null!;
    public /*ICollection<Category>*/ Category Category {  get; set; } = null!;
}
