using IComp.Core;
using IComp.Core.Entities;
using IComp.Service.DTOs.ProcessorDTOs;
using IComp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IComp.Service.Implementations
{
    public class ProcessorService : IProcessorService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProcessorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        //ProcessorGetDto
        public async Task<ProcessorPostDTO> CreateAsync(ProcessorPostDTO postDTO)
        {
            
            Processor processor = new Processor
            {
                Model = postDTO.Model,
                CoreCount = postDTO.CoreCount,
                Count = postDTO.Count,
                Price = postDTO.Price,  
                Speed = postDTO.Speed,
                ProcessorSerieId = postDTO.ProcessorSerieId,
            };

            await _unitOfWork.ProcessorRepository.AddAsync(processor);
            await _unitOfWork.CommitAsync();

            return postDTO;
        }
    }
}
