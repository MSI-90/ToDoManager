using Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class User : IdentityUser
{
    [StringLength(50)]
    public string FirstName { get; set; } = string.Empty;

    [StringLength(70)]
    public string LastName { get; set; } = string.Empty;
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }
    public ICollection<TaskItem>? Tasks { get; set; }
}
