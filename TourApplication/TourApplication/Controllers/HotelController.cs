using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TourApplication.Mappings;
using TourApplication.Services.Interfaces;
using TourApplication.ViewModels;

namespace TourApplication.Controllers
{
    public class HotelController : Controller
    {
        private  IHotelServices _hotelServices { get; set; }

        public HotelController(IHotelServices hotelServices)
        {
            _hotelServices = hotelServices;
        }

        public IActionResult Overview(string filter)
        {
           
            var hotels = _hotelServices.GetWithFilters(filter);

            var hotelsToView = hotels.Select(x => x.ToOverviewModel()).ToList();

            return View(hotelsToView);
        }
        public IActionResult ManageOverview(string errorMessage, string successMessage)
        {
            ViewBag.ErrorMessage = errorMessage;
            ViewBag.SuccessMessage = successMessage;

            var hotels = _hotelServices.GetAllHotels();

            var hotelsToView = hotels.Select(x=> x.ToOverviewModel()).ToList();

            return View(hotelsToView);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(HotelCreateModel hotel)
        {
            if (ModelState.IsValid)
            {
                var domainModel = hotel.ToModel();
                var response = _hotelServices.Create(domainModel);

                if (response.IsSuccessful)
                {
                
                    return RedirectToAction("ManageOverview", new { SuccessMessage = "Hotel created sucessfully" });
                }
                else
                {
                    return RedirectToAction("ManageOverview", new { ErrorMessage = response.Message });
                }
            }

            return View(hotel);
        }

        public IActionResult Details(int id)
        {
            var hotelToView = _hotelServices.GetById(id);

            if (hotelToView == null)
            {
                return RedirectToAction("ManageOverview", new { ErrorMessage = $"There isn't Hotel with Id {id}" });
            }
            else
            {
                var hotel = hotelToView.ToDetailsModel();
                return View(hotel);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var hotelToEdit = _hotelServices.GetById(id);

            if (hotelToEdit == null)
            {
                return RedirectToAction("ManageOverview", new { ErrorMessage = $"There isn't Hotel with Id {id}" });
            }
            else
            {
                var hotel = hotelToEdit.ToUpdateModel();
                return View(hotel);
            }
        }

        [HttpPost]
        public IActionResult Edit(HotelUpdateModel hotel)
        {
            if (ModelState.IsValid)
            {
                var domainModel = hotel.ToModel();
                var response = _hotelServices.Update(domainModel);

                if (response.IsSuccessful)
                {

                    return RedirectToAction("ManageOverview", new { SuccessMessage = "Hotel updated sucessfully" });
                }
                else
                {
                    return RedirectToAction("ManageOverview", new { ErrorMessage = response.Message });
                }
            }

            return View(hotel);
        }

        public IActionResult Delete(int id)
        {
            var response = _hotelServices.Delete(id);

            if (response.IsSuccessful)
            {
                return RedirectToAction("ManageOverview", new { SuccessMessage = "Hotel deleted sucessfully" });
            }
            else
            {
                return RedirectToAction("ManageOverview", new { ErrorMessage = response.Message });
            }
        }
    }
}
