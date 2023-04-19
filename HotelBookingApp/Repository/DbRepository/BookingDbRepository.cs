using HotelBookingApp.Data;
using HotelBookingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApp.Repository.DbRepository
{
    public class BookingDbRepository : IBookingRepository
    {
        HotelDbContext _context;
        Room room;
        public BookingDbRepository(HotelDbContext context)
        {
            _context = context;
        }

        public Task AddBooking(Booking booking)
        {
            this._context.Add(booking);
            return this._context.SaveChangesAsync();
        }

        public Task DeleteBooking(int bookingId)
        {
            var booking = this._context.Bookings.FindAsync(bookingId);
            if (booking.Result != null)
            {
                this._context.Bookings.Remove(booking.Result);
            }

            return this._context.SaveChangesAsync();
        }

        public Task<List<Booking>> GetAllBooking()
        {
            return this._context.Bookings.Include(c=> c.Room).AsNoTracking().ToListAsync();
        }

        public Task<Booking> GetBookingById(int booking_id)
        {
            var booking = this._context.Bookings
                .Include(e => e.User)
                .Include(e => e.Room)
                .FirstOrDefaultAsync(m => m.Id == booking_id);

            if (booking == null)
            {
                return null;
            }

            return booking;
        }

        public Task UpdateBooking(int booking_id, Booking booking)
        {
            this._context.Update(booking);
            return this._context.SaveChangesAsync();
        }
    }
}
