using App.Repository.Entities.Abstract;

namespace App.Repository.Entities.Concrete;

public class Room : IAuditEntity
{
    public int Id { get; set; }
    public string RoomNumber { get; set; }
    public string CoverImage { get; set; }
    public decimal Price { get; set; }
    public string Title { get; set; }
    public string BedCount { get; set; }
    public string BathCount { get; set; }
    public bool HasWifi { get; set; }
    public string Description { get; set; }
    
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime DeletedAt { get; set; }
}