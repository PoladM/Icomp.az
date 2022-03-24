using IComp.Service.DTOs.AppUserDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace IComp.Service.Helpers
{
    public class LayoutService
    {

        public AppUserLoginPostDto GetLoginPost()
        {
            return new AppUserLoginPostDto();
        }
    }
}
