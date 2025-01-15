namespace App.Repository.UnitOfWork;

public interface IUnitOfWork
{
    Task SaveChangesAsync();
}