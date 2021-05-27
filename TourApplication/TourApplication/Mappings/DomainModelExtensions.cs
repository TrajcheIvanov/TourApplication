using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TourApplication.Models;
using TourApplication.ViewModels;

namespace TourApplication.Mappings
{
    public static class DomainModelExtensions
    {
        public static HotelOverviewModel ToOverviewModel(this Hotel hotel)
        {
            return new HotelOverviewModel()
            {
                Id = hotel.Id,
                Name = hotel.Name,
                Destination = hotel.Destination,
                ImageUrl = hotel.ImageUrl,
                Price = hotel.Price
            };
        }

        public static HotelDetailsModel ToDetailsModel(this Hotel hotel)
        {
            return new HotelDetailsModel()
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

        public static HotelUpdateModel ToUpdateModel(this Hotel hotel)
        {
            return new HotelUpdateModel()
            {
                Name = hotel.Name,
                Destination = hotel.Destination,
                ImageUrl = hotel.ImageUrl,
                Price = hotel.Price,
                Description = hotel.Description,
                Amenities = hotel.Amenities
            };
        }

        public static UserViewModel ToViewModel(this ApplicationUser user, string roleName)
        {
            return new UserViewModel()
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                RoleName = roleName
            };
        }

        public static BookingManageModel ToViewModel(this Booking booking)
        {
            return new BookingManageModel()
            {
                Id = booking.Id,
                Name = booking.Name,
                Surname = booking.Surname,
                Email = booking.Email,
                BookStatus = booking.BookStatus,

            };
        }
    }
}
