using IComp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IComp.Service.DTOs.ProductDTOs
{
    public class ProductListItemDto
    {
        public int ProcessorId { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public int DestinationId { get; set; }
        public int? HardDiscId { get; set; }
        public int? SSDId { get; set; }
        public int ProdMemoryId { get; set; }
        public int MotherBoardId { get; set; }
        public int ProdTypeId { get; set; }
        public int VideoCardId { get; set; }
        public int ColorId { get; set; }
        public int SoftwareId { get; set; }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public bool IsDeleted { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public List<ProductImage> ProductImages { get; set; }

        public Processor Processor { get; set; }
        public VideoCard VideoCard { get; set; }
        public MotherBoard MotherBoard { get; set; }
        public ProdType ProdType { get; set; }
        public ProdMemory ProdMemory { get; set; }
        public Brand Brand { get; set; }
        public Destination Destination { get; set; }
        public HardDisc HardDisc { get; set; }
        public SSD SSD { get; set; }
        public Category Category { get; set; }
        public Color Color { get; set; }
        public Software Software { get; set; }
    }
}
