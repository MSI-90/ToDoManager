using Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class User : IdentityUser
{
    [Column("name")]
    [StringLength(50)]
    public string FirstName { get; set; } = string.Empty;

    [Column("sername")]
    [StringLength(70)]
    public string LastName { get; set; } = string.Empty;
    public ICollection<TaskItem>? Tasks { get; set; }
}
