using IComp.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IComp.Service.DTOs.ProductDTOs
{
    public class ProductGetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public decimal SalePrice { get; set; }
        public decimal CostPrice { get; set; }
        public decimal DiscountPercent { get; set; }

        public int Count { get; set; }

        [Range(1, 5)]
        public int Rate { get; set; }

        public bool IsAvailable { get; set; }
        public bool IsNew { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsPopular { get; set; }
        public bool HasBluetooth { get; set; }
        public bool HasWifi { get; set; }

        [Required]
        [StringLength(maximumLength: 100)]
        public string SoundType { get; set; }
        [Required]
        [StringLength(maximumLength: 100)]
        public string InputPorts { get; set; }
        [Required]
        [StringLength(maximumLength: 100)]
        public string USB { get; set; }
        [Required]
        [StringLength(maximumLength: 100)]
        public string USBTypeC { get; set; }
        [Required]
        [StringLength(maximumLength: 100)]
        public string Network { get; set; }
        [Required]
        [StringLength(maximumLength: 100)]
        public string PowerSupply { get; set; }
        [Required]
        [StringLength(maximumLength: 100)]
        public string Weight { get; set; }
        [Required]
        [StringLength(maximumLength: 100)]
        public string WarrantyPeriod { get; set; }


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
        public List<ProductImage> ProductImages { get; set; }
        public List<ProductComment> ProductComments { get; set; }
    }
}
