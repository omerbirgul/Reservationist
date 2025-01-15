using App.Repository.Database;
using App.Repository.Entities.Concrete;

namespace App.Repository.GenericRepositories.RoomRepositories;

public class RoomRepository : GenericRepository<Room>, IRoomRepository
{
    public RoomRepository(AppDbContext context) : base(context)
    {
    }
}