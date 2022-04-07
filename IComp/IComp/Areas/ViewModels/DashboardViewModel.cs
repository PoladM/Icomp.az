using IComp.Core.Entities;
using System.Collections.Generic;

namespace IComp.Areas.ViewModels
{
    public class DashboardViewModel
    {
        public decimal TotalProfit { get; set; }
        public decimal TotalSales { get; set; }
        public int NewCostumer { get; set; }
        public int OrderCount { get; set; }
    }
}
