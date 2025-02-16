using App.Repository.Entities.Abstract;
using Microsoft.AspNetCore.Identity;

namespace App.Repository.Entities.Concrete;

public class AppRole : IdentityRole<string>, IAuditEntity
{
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}