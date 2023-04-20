namespace HotelBookingApp.Models
{
    public class Room
    {
        public int Id { get; set; }
        public bool Status { get; set; }
        public ICollection<Booking> Bookings { get; set; }
        public RoomCategory Category { get; set; }
        public int CategoryId { get; set; }

    }
}
