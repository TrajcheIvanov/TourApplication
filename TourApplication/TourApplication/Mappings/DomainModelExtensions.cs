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
    }
}
