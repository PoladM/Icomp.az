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
        //    var result3 = await _roleManager.CreateAsync(new IdentityRole("Member"));

        //    AppUser appUser = await _userManager.FindByNameAsync("poladm");

        //    var result = await _userManager.AddToRoleAsync(appUser, "Member");

        //    return Ok();
        //}


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
    }
}
