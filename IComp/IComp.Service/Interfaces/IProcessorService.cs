using IComp.Core.Entities;
using IComp.Service.DTOs.ProcessorDTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IComp.Service.Interfaces
{
    public interface IProcessorService
    {
        Task<ProcessorPostDTO> CreateAsync(ProcessorPostDTO postDTO);
    }
}
