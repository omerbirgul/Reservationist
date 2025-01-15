using App.Repository.Database;
using App.Repository.Entities.Concrete;

namespace App.Repository.GenericRepositories.HotelServiceRepositories;

public class HotelServiceRepository : GenericRepository<HotelService>, IHotelServiceRepository
{
    public HotelServiceRepository(AppDbContext context) : base(context)
    {
    }
}