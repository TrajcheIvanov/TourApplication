using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TourApplication.Models;
using TourApplication.Repositories.Interfaces;

namespace TourApplication.Repositories
{
    public class HotelRepository : BaseRepository<Hotel>, IHotelRepository
    {
        public HotelRepository(TourApplicationDbContext context) : base(context)
        {

        }

        public bool CheckIfExists(string hotelName)
        {
            var hotel = _context.Hotels.FirstOrDefault(x => x.Name.ToLower() == hotelName.ToLower());

            if (hotel != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Hotel> GetWithFilters(string filter)
        {
           

            if (filter != null)
            {
                return _context.Hotels.Where(x => x.Name.Contains(filter) || x.Destination.Contains(filter)).ToList();
            }
            else
            {
                return _context.Hotels.ToList();
            }

        }
    }
}
