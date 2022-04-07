using IComp.Areas.ViewModels;
using IComp.Core.Entities;
using IComp.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace IComp.Areas.manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "SuperAdmin, Admin, Reader, Editor, Reader")]

    public class DashboardController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly UserManager<AppUser> _userManager;

        public DashboardController(IOrderService orderService, UserManager<AppUser> userManager)
        {
            _orderService = orderService;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var totalProfit = await _orderService.GetTotalProfit();

            var orders = await _orderService.GetAllOrder();

            var totalSales = await _orderService.GetTotalSales();

            var customers = _userManager.Users.Where(x => !x.IsAdmin);

            DashboardViewModel viewModel = new DashboardViewModel
            {
                TotalProfit = totalProfit,
                NewCostumer = customers.Count(),
                OrderCount = orders.Count(),
                TotalSales = totalSales,
            };
            
            return View(viewModel);
        }
    }
}
