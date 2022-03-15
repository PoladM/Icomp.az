using IComp.Core;
using IComp.Core.Repositories;
using IComp.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IComp.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreDbContext _context;
        private ProcessorRepository _processorRepository;
        private ProcessorSerieRepository _processorSerieRepository;
        private VideoCardRepository _videoCardRepository;
        private VCSerieRepository _vcSerieRepository;

        
        public UnitOfWork(StoreDbContext context)
        {
            _context = context;
        }

        public IProcessorRepository ProcessorRepository => _processorRepository ?? new ProcessorRepository(_context);

        public IProcessorSerieRepository ProcessorSerieRepository => _processorSerieRepository ?? new ProcessorSerieRepository(_context);

        public IVideoCardRepository VideoCardRepository => _videoCardRepository ?? new VideoCardRepository(_context);

        public IVCSerieRepository VCSerieRepository => _vcSerieRepository ?? new VCSerieRepository(_context);

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
