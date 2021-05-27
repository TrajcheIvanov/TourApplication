using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TourApplication.Models;

namespace TourApplication.ViewModels
{
    public class ConfirmBookingViewModel
    {
        [Required]
        public string BookingCode { get; set; }
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }
        
        public string Email { get; set; }

        public BookStatus BookingStatus { get; set; }
    }
}
