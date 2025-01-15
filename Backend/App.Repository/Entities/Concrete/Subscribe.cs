using System.Net.Mail;
using App.Repository.Entities.Abstract;

namespace App.Repository.Entities.Concrete;

public class Subscribe : IAuditEntity
{
    public int Id { get; set; }
    public MailAddress Mail { get; set; }
    
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime DeletedAt { get; set; }
}