namespace App.Repository.Database;

public class ConnectionStringOption
{
    public const string Key = "ConnectionStrings";
    public string DefaultConnection { get; set; } = default!;
}