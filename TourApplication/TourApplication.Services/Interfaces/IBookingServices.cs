using System;
using System.Collections.Generic;
using System.Text;
using TourApplication.Models;
using TourApplication.Services.DtoModels;

namespace TourApplication.Services.Interfaces
{
    public interface IBookingServices
    {
        StatusModel Create(Booking domainModel);
        Booking GetById(int id);
        Booking CheckStatus(string bookingCode, string surname);
        List<Booking> GetAll();
        StatusModel Update(Booking bookingForUpdate);
        List<Booking> GetWithFilters(string pending, string processed);
    }
}
