using System;
using System.Collections.Generic;
using System.Text;

namespace IComp.Service.DTOs.ProductDTOs
{
    public class ProductGetDTO
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public bool IsAvailable { get; set; }
        public string ProcName { get; set; }
    }
}
