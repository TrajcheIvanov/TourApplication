using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TourApplication.Models;

namespace TourApplication.ViewModels
{
    public class BookingManageModel
    {
        public int Id { get; set; }

        public BookStatus BookStatus { get; set; }
        
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }
    }
}
