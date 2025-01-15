using App.Repository.Entities.Abstract;

namespace App.Repository.Entities.Concrete;

public class Testimonial : IAuditEntity
{
    public int Id { get; set; }
    public string Description { get; set; }
    public string ClientFullName { get; set; }
    public string ClientImage { get; set; }
    
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime DeletedAt { get; set; }
}