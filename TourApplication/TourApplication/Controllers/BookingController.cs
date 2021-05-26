using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TourApplication.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult ManageOverview()
        {
            return View();
        }
    }
}
