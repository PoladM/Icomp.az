using IComp.Core.Entities;
using IComp.Service.DTOs.AppUserDTOs;
using IComp.Service.Helpers;
using IComp.Service.Implementations;
using IComp.Service.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace IComp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }


        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(AppUserRegisterPostDto postDto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var appUser = await _userManager.FindByNameAsync(postDto.UserName);

            if(appUser != null)
            {
                ModelState.AddModelError("UserName", "The user has already logged in");
                return View();
            }

            appUser = new AppUser
            {
                UserName = postDto.UserName,
                Email = postDto.Email,
                FullName = postDto.FullName,
                IsAdmin = false
            };

            var result = await _userManager.CreateAsync(appUser, postDto.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                    return View();
                }
            }

            var role = await _userManager.AddToRoleAsync(appUser, "Member");

            if (!role.Succeeded)
            {
                foreach (var error in role.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }

            await _signInManager.SignInAsync(appUser, true);

            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        public async Task<IActionResult> Login(AppUserLoginPostDto postDto)
        {
            

            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));

                return BadRequest(message);
            }

            var appUser = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == postDto.UserName && !x.IsAdmin);

            if (appUser == null)
            {
                return BadRequest("UserName or Password is incorrect");
            }

            var result = await _signInManager.PasswordSignInAsync(appUser, postDto.Password, postDto.IsPersistent, false);

            if (!result.Succeeded)
            {
                return BadRequest("UserName or Password is incorrect");

            }



            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("index", "home");
        }
    }
}
