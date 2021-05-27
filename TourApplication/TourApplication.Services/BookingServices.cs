using System;
using System.Collections.Generic;
using System.Text;
using TourApplication.Common;
using TourApplication.Models;
using TourApplication.Repositories.Interfaces;
using TourApplication.Services.DtoModels;
using TourApplication.Services.Interfaces;

namespace TourApplication.Services
{
    public class BookingServices : IBookingServices
    {
        private IBookingRepository _bookingRepository;
        public BookingServices(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public Booking CheckStatus(string bookingCode, string surname)
        {
            return _bookingRepository.CheckStatus(bookingCode, surname);
        }

        public StatusModel Create(Booking domainModel)
        {
            var response = new StatusModel();
            domainModel.BookStatus = BookStatus.Pending;
            domainModel.BookingCode = RandomCodeGenerator.RandomString(6);

            _bookingRepository.Add(domainModel);

            GmailSender.SendGmail(domainModel.Email, "Booking Created",
                 $"Your Booking with code {domainModel.BookingCode} is created and in pending status , visit check status section ...");


            response.Message =  domainModel.Id.ToString();

            return response;
        }

        public List<Booking> GetAll()
        {
            return _bookingRepository.GetAll();
        }

        public Booking GetById(int id)
        {
            return _bookingRepository.GetById(id);
        }

        public List<Booking> GetWithFilters(string pending, string processed)
        {
            return _bookingRepository.GetWithFilters(pending, processed);
        }

        public StatusModel Update(Booking bookingForUpdate)
        {
            var response = new StatusModel();

            _bookingRepository.Update(bookingForUpdate);

            return response;
        }
    }
}
