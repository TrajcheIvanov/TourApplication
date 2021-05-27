using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TourApplication.Models
{
    public class Booking
    {
        public int Id { get; set; }

        [Required]
        public string BookingCode { get; set; }
        [Required]
        public BookStatus BookStatus { get; set; }
        [Required]
        public int HotelId { get; set; }

        public Hotel Hotel { get; set; }
        [Required]
        public DateTime FromDate { get; set; }
        [Required]
        public DateTime ToDate { get; set; }
        [Required]
        public int NumberOfPeople { get; set; }
        [Required]
        public int NumberOfRooms { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Email { get; set; }


    }
}
