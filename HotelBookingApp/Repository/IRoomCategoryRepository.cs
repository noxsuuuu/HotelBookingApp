using HotelBookingApp.Models;

namespace HotelBookingApp.Repository
{
    public interface IRoomCategoryRepository
    {
        Task<List<RoomCategory>> GetAllRoomCategories();
    }
}
