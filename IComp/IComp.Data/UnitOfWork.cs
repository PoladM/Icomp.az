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
        private readonly ProcessorRepository _processorRepository;
        private readonly ProcessorSerieRepository _processorSerieRepository;

        
        public UnitOfWork(StoreDbContext context)
        {
            _context = context;
        }

        public IProcessorRepository ProcessorRepository => _processorRepository ?? new ProcessorRepository(_context);

        public IProcessorSerieRepository ProcessorSerieRepository => _processorSerieRepository ?? new ProcessorSerieRepository(_context);

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
