using IComp.Core.Entities;
using IComp.Service.DTOs.AppUserDTOs;
using IComp.Service.Helpers;
using IComp.Service.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IComp.Service.Implementations
{
    public class AppUserService : IAppUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public AppUserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<bool> RegisterUser(AppUserRegisterPostDto viewModel)
        {
            var appUser = await _userManager.FindByNameAsync(viewModel.UserName);

            appUser = new AppUser
            {
                UserName = viewModel.UserName,
                Email = viewModel.Email,
                FullName = viewModel.FullName,
                IsAdmin = false
            };

            var result = await _userManager.CreateAsync(appUser, viewModel.Password);

            await _signInManager.SignInAsync(appUser, true);
            return true;
        }

       
    }
}
