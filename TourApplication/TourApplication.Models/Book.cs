using System;
using System.Collections.Generic;
using System.Text;

namespace TourApplication.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string BookingCode { get; set; }

        public BookStatus BookStatus { get; set; }

        public int HotelId { get; set; }

        public Hotel Hotel { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public int NumberOfPeople { get; set; }

        public int NumberOfRooms { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }


    }
}
