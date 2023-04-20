using HotelBookingApp.Data;
using HotelBookingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApp.Repository.DbRepository
{
    public class RoomCategoryDbRepository : IRoomCategoryRepository
    {
        HotelDbContext _db;

        public RoomCategoryDbRepository(HotelDbContext db)
        {
            _db = db;
        }
        public Task<List<RoomCategory>> GetAllRoomCategories()
        {
            return this._db.RoomsCategories.ToListAsync();
        }
    }
}
