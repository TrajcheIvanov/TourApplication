using System;
using System.Collections.Generic;
using System.Text;
using TourApplication.Models;
using TourApplication.Services.DtoModels;

namespace TourApplication.Services.Interfaces
{
    public interface IHotelServices
    {
        List<Hotel> GetAllHotels();

        List<Hotel> GetWithFilters(string filter);

        Hotel GetById(int id);

        StatusModel Create(Hotel hotel);

        StatusModel Delete(int id);

        StatusModel Update(Hotel hotel);

    }
}
