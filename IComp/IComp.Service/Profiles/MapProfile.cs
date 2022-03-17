﻿using AutoMapper;
using IComp.Core.Entities;
using IComp.Service.DTOs.BrandDTOs;
using IComp.Service.DTOs.CategoryDTOs;
using IComp.Service.DTOs.HardDiscCapacityDTOs;
using IComp.Service.DTOs.HardDiscDTOs;
using IComp.Service.DTOs.MemoryCapacityDTOs;
using IComp.Service.DTOs.MemoryDTOs;
using IComp.Service.DTOs.ProcessorDTOs;
using IComp.Service.DTOs.ProcessorSerieDTOs;
using IComp.Service.DTOs.VCSerieDTOs;
using IComp.Service.DTOs.VideoCardDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace IComp.Service.Profiles
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<ProcessorSerie, ProcessorSerieGetDto>();
            CreateMap<ProcessorPostDTO, Processor>();
            CreateMap<Processor, ProcessorPostDTO>();
            CreateMap<ProcessorSeriePostDto, ProcessorSerie>();
            CreateMap<ProcessorSerie, ProcessorSeriePostDto>();
            CreateMap<VideoCardPostDto, VideoCard>();
            CreateMap<VideoCard, VideoCardPostDto>();
            CreateMap<VideoCardSerie, VCSerieGetDto>();
            CreateMap<VCSeriePostDto, VideoCardSerie>();
            CreateMap<ProdMemory, MemoryPostDto>();
            CreateMap<MemoryCapacity, MCapacityGetDto>();
            CreateMap<MemoryCapacity, MCapacityPostDto>();
            CreateMap<MCapacityPostDto, MemoryCapacity>();
            CreateMap<MemoryPostDto, ProdMemory>();
            CreateMap<HDDCapacity, HardDiscCapacityGetDto>();
            CreateMap<HardDiscPostDto, HardDisc>();
            CreateMap<HardDisc, HardDiscPostDto>();
            CreateMap<HardDiscCapacityPostDto, HDDCapacity>();
            CreateMap<HDDCapacity, HardDiscCapacityPostDto>();
            CreateMap<BrandPostDto, Brand>();
            CreateMap<Brand, BrandPostDto>();
            CreateMap<CategoryPostDto, Category>();
            CreateMap<Category, CategoryPostDto>();

        }
    }
}
