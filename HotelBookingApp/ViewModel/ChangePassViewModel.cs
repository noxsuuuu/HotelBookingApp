using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace HotelBookingApp.ViewModel
{
    public class ChangePassViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }


        [Required]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("NewPassword", ErrorMessage = "Password and confirm password doesnt match")]
        public string ConfirmNewPassword { get; set; }
    }
}
