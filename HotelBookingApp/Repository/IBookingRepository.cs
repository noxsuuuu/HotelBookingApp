using HotelBookingApp.Models;

namespace HotelBookingApp.Repository
{
    public interface IBookingRepository
    {
        Task<List<Booking>> GetAllBooking();
        Task<Booking> GetBookingById(int booking_id);
        Task AddBooking(Booking booking);
        Task DeleteBooking(int booking_id);
        Task UpdateBooking(int booking_id, Booking booking);
    }
}
