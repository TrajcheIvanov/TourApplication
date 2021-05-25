using System;
using System.Collections.Generic;
using System.Text;
using TourApplication.Models;
using TourApplication.Repositories.Interfaces;
using TourApplication.Services.DtoModels;
using TourApplication.Services.Interfaces;

namespace TourApplication.Services
{
    public class HotelServices : IHotelServices
    {
        private IHotelRepository _hotelRepository { get; set; }

        public HotelServices(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public List<Hotel> GetAllHotels()
        {
            return _hotelRepository.GetAll();
        }

        public List<Hotel> GetWithFilters(string filter)
        {
            return _hotelRepository.GetWithFilters(filter);
        }

        public Hotel GetById(int id)
        {
            return _hotelRepository.GetById(id);
        }

        public StatusModel Create(Hotel hotel)
        {
            var response = new StatusModel();

            if (_hotelRepository.CheckIfExists(hotel.Name))
            {
                response.IsSuccessful = false;
                response.Message = $"Hotel with Name {hotel.Name} allready exist";

                return response;
            }


            hotel.DateCreated = DateTime.Now;
            _hotelRepository.Add(hotel);

            return response;
        }

        public StatusModel Delete(int id)
        {
            var response = new StatusModel();
            var hotel = _hotelRepository.GetById(id);

            if (hotel == null)
            {
                response.IsSuccessful = false;
                response.Message = $"The Hotel with id {id} was not found";
            }
            else
            {
                _hotelRepository.Delete(hotel);
            }

            return response;
        }

        public StatusModel Update(Hotel hotel)
        {
            var response = new StatusModel();
            var hotelForUpdate = _hotelRepository.GetById(hotel.Id);
            if (hotelForUpdate != null)
            {
                hotelForUpdate.Amenities = hotel.Amenities;
                hotelForUpdate.Description = hotel.Description;
                hotelForUpdate.Destination = hotel.Destination;
                hotelForUpdate.Price = hotel.Price;
                hotelForUpdate.ImageUrl = hotel.ImageUrl;
                hotelForUpdate.Name = hotel.Name;
                hotelForUpdate.DateModified = DateTime.Now;

                _hotelRepository.Update(hotelForUpdate);
            }
            else
            {
                response.IsSuccessful = false;
                response.Message = $"The Hotel with id {hotel.Id} was not found";
            }

            return response;
        }
    }
}
