using App.Repository.Database;
using App.Repository.Entities.Concrete;

namespace App.Repository.GenericRepositories.StaffRepositories;

public class StaffRepository : GenericRepository<Staff>, IStaffRepository
{
    public StaffRepository(AppDbContext context) : base(context)
    {
    }
}