namespace App.Repository.Entities.Concrete;

public class UserRefreshToken
{
    public string UserId { get; set; }
    public string Code { get; set; }
    public DateTime ExpirationDate { get; set; }
}