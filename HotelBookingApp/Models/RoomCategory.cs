using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HotelBookingApp.Models
{
    public class RoomCategory
    {
        [DisplayName("Category ID")]
        [Key]
        public int Id { get; set; }

        [DisplayName("Room Name")]
        [Required]
        public string CategoryName { get; set; }

        [DisplayName("Room Description")]
        [Required]
        public string Description { get; set; }

        [DisplayName("Price")]
        [DisplayFormat(DataFormatString = "₱{0:N}", ApplyFormatInEditMode = true, NullDisplayText = "")]
        [Required]
        public double Price { get; set; }
        [ValidateNever]
        public ICollection<Room> Rooms { get; set; }
    }
}
