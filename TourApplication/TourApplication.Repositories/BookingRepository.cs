using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TourApplication.Models;
using TourApplication.Repositories.Interfaces;

namespace TourApplication.Repositories
{
    public class BookingRepository : BaseRepository<Booking> , IBookingRepository
    {
        public BookingRepository(TourApplicationDbContext context) : base(context)
        {

        }

        public Booking CheckStatus(string bookingCode, string surname)
        {
            return _context.Bookings.FirstOrDefault(x => x.BookingCode == bookingCode && x.Surname == surname);
        }

        public List<Booking> GetWithFilters(string pending, string processed)
        {
            if (pending != null)
            {
                return _context.Bookings.Where(x => x.BookStatus == BookStatus.Pending).ToList();
            }
            if (processed != null)
            {
                return _context.Bookings.Where(x => x.BookStatus == BookStatus.Processed).ToList();
            }
            else
            {
                return _context.Bookings.ToList();
            }
        }
    }
}
