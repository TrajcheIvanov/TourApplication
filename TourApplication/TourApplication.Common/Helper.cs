using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace TourApplication.Common
{
    public static class Helper
    {
        public static string Admin = "Admin";
        public static string ContentCreator = "Content Creator";
        public static string CustomerSupport = "Customer Support";

        public static List<SelectListItem> GetRolesForDropDown()
        {

            return new List<SelectListItem>
            {
                 new SelectListItem{Value=Helper.Admin,Text=Helper.Admin},
                 new SelectListItem{Value=Helper.ContentCreator,Text=Helper.ContentCreator},
                 new SelectListItem{Value=Helper.CustomerSupport,Text=Helper.CustomerSupport}
            };

        }
    }

  
}
