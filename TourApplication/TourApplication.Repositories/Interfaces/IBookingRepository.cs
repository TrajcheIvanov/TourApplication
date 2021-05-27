using System;
using System.Collections.Generic;
using System.Text;
using TourApplication.Models;

namespace TourApplication.Repositories.Interfaces
{
    public interface IBookingRepository : IBaseRepository<Booking>
    {
        Booking CheckStatus(string bookingCode, string surname);
        List<Booking> GetWithFilters(string pending, string processed);
    }
}
