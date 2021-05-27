using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TourApplication.Models;
using TourApplication.ViewModels;

namespace TourApplication.Mappings
{
    public static class ViewModelExtensions
    {
        public static Hotel ToModel(this HotelCreateModel hotel)
        {
            return new Hotel()
            {
                Name = hotel.Name,
                Destination = hotel.Destination,
                ImageUrl = hotel.ImageUrl,
                Price = hotel.Price,
                Description = hotel.Description,
                Amenities = hotel.Amenities
            };

        }

        public static Hotel ToModel(this HotelUpdateModel hotel)
        {
            return new Hotel()
            {
                Id = hotel.Id,
                Name = hotel.Name,
                Destination = hotel.Destination,
                ImageUrl = hotel.ImageUrl,
                Price = hotel.Price,
                Description = hotel.Description,
                Amenities = hotel.Amenities
            };
        }

        public static Booking ToModel(this BookingViewModel hotel)
        {
            return new Booking()
            {
                HotelId = hotel.HotelId,
                FromDate = hotel.FromDate,
                ToDate = hotel.ToDate,
                NumberOfPeople = hotel.NumberOfPeople,
                NumberOfRooms = hotel.NumberOfRooms,
                Name = hotel.Name,
                Surname = hotel.Surname,
                Email = hotel.Email
            };
        }
    }
}
