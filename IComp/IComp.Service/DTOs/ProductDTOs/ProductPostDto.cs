﻿using IComp.Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IComp.Service.DTOs.ProductDTOs
{
    public class ProductPostDto
    {
        public int ProcessorId { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public int DestinationId { get; set; }
        public int HardDiscId { get; set; }
        public int ProdMemoryId { get; set; }
        public int MotherBoardId { get; set; }
        public int ProdTypeId { get; set; }
        public int VideoCardId { get; set; }
        public int ColorId { get; set; }
        public int SoftwareId { get; set; }

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
        public Category Category { get; set; }
        public Color Color { get; set; }
        public Software Software { get; set; }
        public IFormFile PosterFile { get; set; }
        public List<IFormFile> ImageFiles { get; set; }
        public List<ProductImage> ProductImages { get; set; }

    }
}
