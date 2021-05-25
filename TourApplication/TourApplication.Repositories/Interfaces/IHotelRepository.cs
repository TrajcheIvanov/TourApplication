using System;
using System.Collections.Generic;
using System.Text;
using TourApplication.Models;

namespace TourApplication.Repositories.Interfaces
{
    public interface IHotelRepository : IBaseRepository<Hotel>
    {
        List<Hotel> GetWithFilters(string filter);

        bool CheckIfExists(string hotelName);
    }
}
