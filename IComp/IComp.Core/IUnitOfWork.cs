using IComp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IComp.Core
{
    public interface IUnitOfWork
    {
        IProcessorRepository ProcessorRepository { get; }
        IProcessorSerieRepository ProcessorSerieRepository { get; }
        IVideoCardRepository VideoCardRepository { get; }
        IVCSerieRepository VCSerieRepository { get; }
        IMemoryRepository MemoryRepository { get; }
        IMemoryCapacityRepository MemoryCapacityRepository { get; }
        IMotherBoardRepository MotherBoardRepository { get; }
        IHardDiscRepository HardDiscRepository { get; }
        IHardDiscCapacityRepository HardDiscCapacityRepository { get; }
        IBrandRepository BrandRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IProductRepository ProductRepository { get; }
        IProdTypeRepository ProdTypeRepository { get; }
        IDestinationRepository DestinationRepository { get; }
        int Commit();
        Task<int> CommitAsync();
    }
}
