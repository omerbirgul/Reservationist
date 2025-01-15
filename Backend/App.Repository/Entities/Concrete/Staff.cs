using App.Repository.Entities.Abstract;

namespace App.Repository.Entities.Concrete;

public class Staff : IAuditEntity
{
    public int Id { get; set; }
    public string Image { get; set; }
    public string FullName { get; set; }
    public string Title { get; set; }
    public Uri FaceBookUri { get; set; }
    public Uri TwitterUri { get; set; }
    public Uri InstagramUri { get; set; }
    
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime DeletedAt { get; set; }
}