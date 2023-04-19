using HotelBookingApp.Models;

namespace HotelBookingApp.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
        public Room Room { get; set; }
        public int RoomId { get; set; }

    }
}

