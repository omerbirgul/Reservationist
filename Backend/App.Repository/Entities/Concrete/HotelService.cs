using App.Repository.Entities.Abstract;

namespace App.Repository.Entities.Concrete;

public class HotelService : IAuditEntity, IEntity
{
    public int Id { get; set; }
    public string ServiceIcon { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}