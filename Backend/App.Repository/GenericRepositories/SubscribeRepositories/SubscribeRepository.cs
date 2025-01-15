using App.Repository.Database;
using App.Repository.Entities.Concrete;
using App.Repository.GenericRepositories.StaffRepositories;

namespace App.Repository.GenericRepositories.SubscribeRepositories;

public class SubscribeRepository : GenericRepository<Staff>, IStaffRepository
{
    public SubscribeRepository(AppDbContext context) : base(context)
    {
    }
}