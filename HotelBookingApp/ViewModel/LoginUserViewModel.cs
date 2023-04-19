﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace HotelBookingApp.ViewModel
{
    public class LoginUserViewModel
    {
        [Required]
        [EmailAddress]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
