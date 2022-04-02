﻿using IComp.Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace IComp.Service.DTOs.ProductPartsDTOs
{
    public class ProdProcessorPostDto
    {
        public int ProdTypeId { get; set; }
        public int BrandId { get; set; }
        public int DestinationId { get; set; }
        public int ProcessorId { get; set; }
        public int CategoryId { get; set; }
        public int ColorId { get; set; }

        public string WarrantyPeriod { get; set; }
        public string Speed { get; set; }
        public string Name { get; set; }
        public decimal SalePrice { get; set; }
        public decimal CostPrice { get; set; }
        public decimal DiscountPercent { get; set; }
        public int Count { get; set; }


        public Color Color { get; set; }
        public Category Category { get; set; }
        public ProdType ProdType { get; set; }
        public Brand Brand { get; set; }
        public Destination Destination { get; set; }
        public Processor Processor { get; set; }

        public IFormFile PosterFile { get; set; }
        public List<IFormFile> ImageFiles { get; set; }
        public List<ProductImage> ProductImages { get; set; }


    }
}
