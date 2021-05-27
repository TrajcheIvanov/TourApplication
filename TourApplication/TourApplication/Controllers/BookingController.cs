using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TourApplication.Mappings;
using TourApplication.Models;
using TourApplication.Services.Interfaces;
using TourApplication.ViewModels;

namespace TourApplication.Controllers
{
    public class BookingController : Controller
    {
        private IBookingServices _bookingServices { get; set; }
        private IHotelServices _hotelServices { get; set; }

        public BookingController(IBookingServices bookingServices, IHotelServices hotelServices)
        {
            _bookingServices = bookingServices;
            _hotelServices = hotelServices;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult BookHotel(int id)
        {
            BookingViewModel model = new BookingViewModel();
            model.HotelId = id;
            model.Hotel = _hotelServices.GetById(id).ToOverviewModel();

            return View(model);
        }


        [AllowAnonymous]
        [HttpPost]
        public IActionResult BookHotel(BookingViewModel model)
        {
            if (ModelState.IsValid)
            {
                var domainModel = model.ToModel();

                var response = _bookingServices.Create(domainModel);

                return RedirectToAction("BookingCreated", "Booking" , new { id = response.Message });
            }

            return View(model);
        }

        [AllowAnonymous]
        public IActionResult BookingCreated(string id)
        {
            var domainModel = _bookingServices.GetById(Convert.ToInt32(id));

            ConfirmBookingViewModel message = new ConfirmBookingViewModel();
            message.BookingCode = domainModel.BookingCode;
            message.Email = domainModel.Email;
            message.Name = domainModel.Name;
            message.Surname = domainModel.Surname;

            return View(message);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult CheckBookingStatus()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult CheckBookingStatus(ConfirmBookingViewModel booking)
        {
            if (ModelState.IsValid)
            {
                var response = _bookingServices.CheckStatus(booking.BookingCode, booking.Surname);

                booking.BookingStatus = response.BookStatus;
                booking.Email = response.Email;
                booking.Name = response.Name;

                return RedirectToAction("BookingStatusView", "Booking", booking);
            }
            return View(booking);
        }

        [AllowAnonymous]
        public IActionResult BookingStatusView(ConfirmBookingViewModel booking)
        {
            return View(booking);
        }

        [Authorize(Roles = "Admin,Customer Support")]
        public IActionResult ManageOverview(string pending, string processed) 
        {
            var bookings = _bookingServices.GetWithFilters(pending, processed);

            var bookingsToView = bookings.Select(x => x.ToViewModel());

            return View(bookingsToView);
        }

        [Authorize(Roles = "Admin,Customer Support")]
        public IActionResult ChangeStatus(int id , string status)
        {

            var bookingForUpdate = _bookingServices.GetById(id);

            if (status == "Pending")
            {
                bookingForUpdate.BookStatus = BookStatus.Processed;
            }
            else
            {
                bookingForUpdate.BookStatus = BookStatus.Pending;
            }

            var response = _bookingServices.Update(bookingForUpdate);

            return RedirectToAction("ManageOverview");
        }
    }
}
