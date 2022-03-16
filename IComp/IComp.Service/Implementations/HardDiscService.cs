using AutoMapper;
using IComp.Core;
using IComp.Service.DTOs;
using IComp.Service.DTOs.HardDiscCapacityDTOs;
using IComp.Service.DTOs.HardDiscDTOs;
using IComp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IComp.Service.Implementations
{
    public class HardDiscService : IHardDiscService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public HardDiscService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public Task<HardDiscGetDto> CreateAsync(HardDiscPostDto postDTO)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public PaginatedListDto<HardDiscListItemDto> GetAllProd(int page)
        {
            throw new NotImplementedException();
        }

        public Task<HardDiscPostDto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public List<HardDiscCapacityGetDto> GetCapacitiesForHDD()
        {
            var capacities = _unitOfWork.HardDiscCapacityRepository.GetAll(x => x.IsHDD);

            var capacitiesDto = _mapper.Map<List<HardDiscCapacityGetDto>>(capacities);

            return capacitiesDto;
        }
        //Mapping
        public List<HardDiscCapacityGetDto> GetCapacitiesForSSD()
        {
            var capacities = _unitOfWork.HardDiscCapacityRepository.GetAll(x => x.IsSSD);

            var capacitiesDto = _mapper.Map<List<HardDiscCapacityGetDto>>(capacities);

            return capacitiesDto;
        }

        public Task RestoreAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int id, HardDiscPostDto postDTO)
        {
            throw new NotImplementedException();
        }
    }
}
