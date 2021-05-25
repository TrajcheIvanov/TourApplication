using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TourApplication.Models
{
    public class Hotel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 35, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public string Destination { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Amenities { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        public DateTime? DateModified { get; set; }
    }
}
