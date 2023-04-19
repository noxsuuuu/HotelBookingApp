using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HotelBookingApp.Models
{
    public class ApplicationUser : IdentityUser
    {

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [NotMapped]
        [DisplayName("Full Name")]
        public string Full_Name
        {
            get { return FirstName + " " + LastName; }
            set { }
        }

        [DisplayName("Email Address")]
        [EmailAddress]
        // [EmailExist]
        public string? Email { get; set; }

        [RegularExpression("^(09|\\+639)\\d{9}$", ErrorMessage = "Invalid phone number.")]
        public string PhoneNumber { get; set; }
/*
        [ValidateNever]
        public ICollection<Room> Room { get; set; }
*/
        [ValidateNever]
        public ICollection<Booking> Booking { get; set; }

        [ValidateNever]
        public IdentityRole Role { get; set; }

        public string RoleId { get; set; }

    }
}
