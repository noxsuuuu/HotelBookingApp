using HotelBookingApp.Data;
using HotelBookingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApp.Repository.DbRepository
{
    public class RoomDbRepository : IRoomRepository
    {

        HotelDbContext _context;

        public RoomDbRepository(HotelDbContext context)
        {
            _context = context;
        }

        public Task AddRoom(Room room)
        {
            this._context.Add(room);
            return this._context.SaveChangesAsync();
        }

        public Task DeleteRoom(int room_id)
        {
            var room = this._context.Rooms.FindAsync(room_id);
            if (room.Result != null)
            {
                this._context.Rooms.Remove(room.Result);
            }

            return this._context.SaveChangesAsync();
        }

        public Task<List<Room>> GetAllRoom()
        {
            return this._context.Rooms.Include(e => e.Category).AsNoTracking().ToListAsync();
        }

        public Task<Room> GetRoomById(int room_id)
        {
            var room = this._context.Rooms
                           .Include(e => e.Category)
                           .FirstOrDefaultAsync(m => m.Id == room_id);

            if (room == null)
            {
                return null;
            }

            return room;
        }

        public Task UpdateRoom(int room_id, Room room)
        {
            this._context.Update(room);
            return this._context.SaveChangesAsync();
        }
    }
}
