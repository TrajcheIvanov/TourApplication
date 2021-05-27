using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TourApplication.Models;

namespace TourApplication.ViewModels
{
    public class BookingViewModel
    {
        
        [Required]
        public int HotelId { get; set; }

        public HotelOverviewModel Hotel { get; set; }
        [Required]
        public DateTime FromDate { get; set; }
        [Required]
        public DateTime ToDate { get; set; }
        [Required]
        [Range(1,10,ErrorMessage ="Number of people can be between 1 and 10")]
        public int NumberOfPeople { get; set; }
        [Required]
        [Range(1, 5, ErrorMessage = "Number of rooms can be between 1 and 5")]
        public int NumberOfRooms { get; set; }
        [Required]
        [StringLength(maximumLength: 35, MinimumLength = 2)]
        public string Name { get; set; }
        [Required]
        [StringLength(maximumLength: 35, MinimumLength = 2)]
        public string Surname { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
