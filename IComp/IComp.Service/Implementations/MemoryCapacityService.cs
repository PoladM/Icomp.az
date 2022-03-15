using AutoMapper;
using IComp.Core;
using IComp.Service.DTOs;
using IComp.Service.DTOs.MemoryCapacityDTOs;
using IComp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IComp.Service.Implementations
{
    public class MemoryCapacityService : IMemoryCapacityService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MemoryCapacityService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public Task<MCapacityGetDto> CreateAsync(MCapacityPostDto postDTO)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public PaginatedListDto<MCapacityListItemDto> GetAllProd(int page)
        {
            throw new NotImplementedException();
        }

        public Task<MCapacityGetDto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int id, MCapacityPostDto postDTO)
        {
            throw new NotImplementedException();
        }
    }
}
