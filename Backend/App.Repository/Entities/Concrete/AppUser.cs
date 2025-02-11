using App.Repository.Entities.Abstract;
using Microsoft.AspNetCore.Identity;

namespace App.Repository.Entities.Concrete;

public class AppUser : IdentityUser<string>, IAuditEntity
{
    public string City { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime DeletedAt { get; set; }
}