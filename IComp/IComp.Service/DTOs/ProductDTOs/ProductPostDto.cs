﻿using IComp.Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
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

        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public int Count { get; set; }

        public Processor Processor { get; set; }
        public VideoCard VideoCard { get; set; }
        public MotherBoard MotherBoard { get; set; }
        public ProdType ProdType { get; set; }
        public ProdMemory ProdMemory { get; set; }
        public Brand Brand { get; set; }
        public Destination Destination { get; set; }
        public HardDisc HardDisc { get; set; }
        public Category Category { get; set; }
        public IFormFile PosterFile { get; set; }
        public List<IFormFile> ImageFiles { get; set; }
        public List<ProductImage> ProductImages { get; set; }

    }
}