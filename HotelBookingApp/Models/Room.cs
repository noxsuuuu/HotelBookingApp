﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingApp.Models
{
    public class Room
    {
        [DisplayName("Room ID")]
        [Key]
        public int Id { get; set; }
        [DisplayName("Room Status")]
        public bool Status { get; set; }
        public ICollection<Booking> Bookings { get; set; }
        [ValidateNever]
        public RoomCategory Category { get; set; }
        [DisplayName("Category ID")]
        public int CategoryId { get; set; }


        [NotMapped]
        public string DisplayStatus => Status ? "Available" : "Booked";
    }
}
