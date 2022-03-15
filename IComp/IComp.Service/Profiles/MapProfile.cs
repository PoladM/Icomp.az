using AutoMapper;
using IComp.Core.Entities;
using IComp.Service.DTOs.ProcessorDTOs;
using IComp.Service.DTOs.ProcessorSerieDTOs;
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

        }
    }
}
