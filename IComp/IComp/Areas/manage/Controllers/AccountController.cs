using IComp.Areas.ViewModels;
using IComp.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace IComp.Areas.manage.Controllers
{
    [Area("manage")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        //public async Task<IActionResult> Create()
        //{
        //    AppUser appUser = new AppUser
        //    {
        //        FullName = "Super Admin",
        //        UserName = "SuperAdmin",
        //        Email = "superadmin@gmail.com"
        //    };

        //    var result = await _userManager.CreateAsync(appUser, "Superadmin2022");

        //    return Ok();
        //}

        //public async Task<IActionResult> Role()
        //{
        //    var result3 = await _roleManager.CreateAsync(new IdentityRole("Reader"));
        //    if (result3.Succeeded)
        //    {
        //        return Ok();
        //    }
        //    return BadRequest();
        //}

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AdminRegisterViewModel admin)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            AppUser appUser = new AppUser
            {
                FullName = admin.FullName,
                UserName = admin.UserName,
                Email = admin.Email
            };

            var result = await _userManager.CreateAsync(appUser, admin.Password);

            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View();
            }
            var role = await _userManager.AddToRoleAsync(appUser, admin.AdminRoles.ToString());

            if (!role.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View();
            }

            return RedirectToAction("index", "dashboard");
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Login(AdminLoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View();

            AppUser admin = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == viewModel.UserName && x.IsAdmin);

            if (admin == null)
            {
                ModelState.AddModelError("", "UserName or Password is incorrect");
                return View();
            }

            var result = await _signInManager.PasswordSignInAsync(admin, viewModel.Password, viewModel.IsPersistent, false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "UserName or Password is incorrect");
                return View();
            }

            return RedirectToAction("index", "dashboard");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("login", "account","manage");
        }
    }
}
