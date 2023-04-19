using HotelBookingApp.Models;

namespace HotelBookingApp.Repository
{
    public interface IRoomRepository
    {
        Task<List<Room>> GetAllRoom();
        Task<Room> GetRoomById(int room_id);
        Task AddRoom(Room room);
        Task DeleteRoom(int room_id);
        Task UpdateRoom(int room_id, Room room);
    }
}
