using AutoMapper;
using IComp.Core;
using IComp.Core.Entities;
using IComp.Service.DTOs;
using IComp.Service.DTOs.MemoryDTOs;
using IComp.Service.DTOs.MemorySerieGetDTOs;
using IComp.Service.Exceptions;
using IComp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IComp.Service.Implementations
{
    public class MemoryService : IMemoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MemoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<MemoryGetDto> CreateAsync(MemoryPostDto postDTO)
        {
            if (await _unitOfWork.MemoryRepository.IsExistAsync(x => x.ModelName.ToLower().Trim() == postDTO.ModelName.ToLower().Trim() && !x.IsDeleted))
            {
                throw new RecordDuplicatedException("ModelName already exist with name " + postDTO.ModelName);
            }
            if (!await _unitOfWork.ProcessorSerieRepository.IsExistAsync(x => x.Id == postDTO.MemoryCapacityId))
            {
                throw new ItemNotFoundException("Item not found");
            }

            ProdMemory memory = _mapper.Map<ProdMemory>(postDTO);

            await _unitOfWork.MemoryRepository.AddAsync(memory);
            await _unitOfWork.CommitAsync();

            return new MemoryGetDto
            {
                Id = memory.Id,
                Model = memory.ModelName
            };
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public PaginatedListDto<MemoryListItemDto> GetAllProd(int page)
        {
            throw new NotImplementedException();
        }

        public Task<MemoryPostDto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public List<MCapacityGetDto> GetProcSeries()
        {
            throw new NotImplementedException();
        }

        public Task RestoreAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int id, MemoryPostDto postDTO)
        {
            throw new NotImplementedException();
        }
    }
}
