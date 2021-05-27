using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TourApplication.Mappings;
using TourApplication.Models;
using TourApplication.Repositories;
using TourApplication.ViewModels;

namespace TourApplication.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EmployeeController : Controller
    {
        private readonly TourApplicationDbContext _db;
        UserManager<ApplicationUser> _userManager;
        RoleManager<IdentityRole> _roleManager;

        public EmployeeController(
           TourApplicationDbContext db,
           UserManager<ApplicationUser> userManager,
           SignInManager<ApplicationUser> signInManager,
           RoleManager<IdentityRole> roleManager
           )
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }

       
        public IActionResult ManageOverview()
        {
            var users = _userManager.Users.ToList();

            var usersToViewModel = new List<UserViewModel>();

            foreach (var user in users)
            {
                var role =  _db.UserRoles.FirstOrDefault(x => x.UserId == user.Id);

                var roleName = _db.Roles.FirstOrDefault(x => x.Id == role.RoleId);

                
                usersToViewModel.Add(user.ToViewModel(roleName.Name));
            }

            return View(usersToViewModel);
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);

            var role = _db.UserRoles.FirstOrDefault(x => x.UserId == user.Id);

            var roleName = _db.Roles.FirstOrDefault(x => x.Id == role.RoleId);

            var userToEdit = user.ToViewModel(roleName.Name);

            return View(userToEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserViewModel userForUpdate)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == userForUpdate.Id);

            user.Name = userForUpdate.Name;
            user.Surname = userForUpdate.Surname;
            user.Email = userForUpdate.Email;

            await _userManager.UpdateAsync(user);

            return RedirectToAction("ManageOverview");
        }

        public async Task<IActionResult> Delete(string id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);

            await _userManager.DeleteAsync(user);

            return RedirectToAction("ManageOverview");
        }
    }
}
