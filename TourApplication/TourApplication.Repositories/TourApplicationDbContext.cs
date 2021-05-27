using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TourApplication.Models;

namespace TourApplication.Repositories
{
    public class TourApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public TourApplicationDbContext(DbContextOptions<TourApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Hotel> Hotels { get; set; }

        public DbSet<Booking> Bookings { get; set; }
    }
}
