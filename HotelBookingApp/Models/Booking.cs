namespace HotelBookingApp.Models
{
    public class Booking
    {
        public string Id { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }

    }
}
