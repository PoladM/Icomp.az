using IComp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IComp.Service.DTOs.MemoryDTOs
{
    public class MemoryPostDto
    {
        public int MemoryCapacityId { get; set; }
        public string ModelName { get; set; }
        public string Speed { get; set; }
        public string DDRType { get; set; }
        public bool IsAvailable { get; set; }
        public double? Price { get; set; }
        public int Count { get; set; }
        
        public List<Product> Products { get; set; }
    }
}
