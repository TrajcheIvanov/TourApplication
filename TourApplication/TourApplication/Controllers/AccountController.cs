using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TourApplication.Common;
using TourApplication.Models;
using TourApplication.Repositories;
using TourApplication.ViewModels;

namespace TourApplication.Controllers
{
    public class AccountController : Controller
    {
        private readonly TourApplicationDbContext _db;
        UserManager<ApplicationUser> _userManager;
        SignInManager<ApplicationUser> _signInManager;
        RoleManager<IdentityRole> _roleManager;

        public AccountController(
           TourApplicationDbContext db,
           UserManager<ApplicationUser> userManager,
           SignInManager<ApplicationUser> signInManager,
           RoleManager<IdentityRole> roleManager
           )
        {
            _db = db;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                        return RedirectToAction("Overview", "Hotel");
                   
                }
                ModelState.AddModelError("", "Invalid login attepmt");
            }

            return View(model);
        }

        public async Task<IActionResult> Register()
        {
            if (!_roleManager.RoleExistsAsync(Helper.Admin).GetAwaiter().GetResult())
            {
                await _roleManager.CreateAsync(new IdentityRole(Helper.Admin));
                await _roleManager.CreateAsync(new IdentityRole(Helper.ContentCreator));
                await _roleManager.CreateAsync(new IdentityRole(Helper.CustomerSupport));
            }
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    
                    UserName = model.Email,
                    Email = model.Email,
                    Name = model.Name,
                    Surname = model.Surname,

                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, model.RoleName);
                   
                    return RedirectToAction("ManageOverview", "Employee");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

   
        public async Task<IActionResult> LogOff()
        {
            var user = User;

            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}
