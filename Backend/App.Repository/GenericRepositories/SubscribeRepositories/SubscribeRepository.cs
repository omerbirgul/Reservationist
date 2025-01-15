using App.Repository.Database;
using App.Repository.Entities.Concrete;
using App.Repository.GenericRepositories.StaffRepositories;

namespace App.Repository.GenericRepositories.SubscribeRepositories;

public class SubscribeRepository : GenericRepository<Subscribe>, ISubscribeRepository
{
    public SubscribeRepository(AppDbContext context) : base(context)
    {
    }
}