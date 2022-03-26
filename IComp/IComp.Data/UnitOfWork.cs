﻿using IComp.Core;
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
        private MemoryRepository _memoryRepository;
        private MemoryCapacityRepository _memoryCapacityRepository;
        private MotherBoardRepository _motherBoardRepository;
        private HardDiscRepository _hardwareDiscRepository;
        private HardDiscCapacityRepository _hardwareDiscCapacityRepository;
        private BrandRepository _brandRepository;
        private CategoryRepository _categoryRepository;
        private ProductRepository _productRepository;
        private ProdTypeRepository _prodTypeRepository;
        private DestinationRepository _destinationRepository;
        private ColorRepository _colorRepository;
        private SoftWareRepository _softwareWareRepository;
        private ProductImageRepository _productImageRepository;
        private SettingRepository _settingRepository;
        private BasketItemRepository _basketItemRepository;
        private ProductCommentRepository _productCommentRepository;
        private OrderRepository _orderRepository;
        private OrderItemRepository _orderItemRepository;

        public UnitOfWork(StoreDbContext context)
        {
            _context = context;
        }

        public IProcessorRepository ProcessorRepository => _processorRepository ?? new ProcessorRepository(_context);

        public IProcessorSerieRepository ProcessorSerieRepository => _processorSerieRepository ?? new ProcessorSerieRepository(_context);

        public IVideoCardRepository VideoCardRepository => _videoCardRepository ?? new VideoCardRepository(_context);

        public IVCSerieRepository VCSerieRepository => _vcSerieRepository ?? new VCSerieRepository(_context);

        public IMemoryRepository MemoryRepository => _memoryRepository ?? new MemoryRepository(_context);

        public IMemoryCapacityRepository MemoryCapacityRepository => _memoryCapacityRepository ?? new MemoryCapacityRepository(_context);

        public IMotherBoardRepository MotherBoardRepository => _motherBoardRepository ?? new MotherBoardRepository(_context);

        public IHardDiscRepository HardDiscRepository => _hardwareDiscRepository ?? new HardDiscRepository(_context);

        public IHardDiscCapacityRepository HardDiscCapacityRepository => _hardwareDiscCapacityRepository ?? new HardDiscCapacityRepository(_context);

        public IBrandRepository BrandRepository => _brandRepository ?? new BrandRepository(_context);

        public ICategoryRepository CategoryRepository => _categoryRepository ?? new CategoryRepository(_context);

        public IProductRepository ProductRepository => _productRepository ?? new ProductRepository(_context);

        public IProdTypeRepository ProdTypeRepository => _prodTypeRepository ?? new ProdTypeRepository(_context);

        public IDestinationRepository DestinationRepository => _destinationRepository ?? new DestinationRepository(_context);

        public IColorRepository ColorRepository => _colorRepository ?? new ColorRepository(_context);

        public ISoftWareRepository SoftWareRepository => _softwareWareRepository ?? new SoftWareRepository(_context);

        public IProductImageRepository ProductImageRepository => _productImageRepository ?? new ProductImageRepository(_context);

        public ISettingRepository SettingRepository => _settingRepository ?? new SettingRepository(_context);

        public IBasketItemRepository BasketItemRepository => _basketItemRepository ?? new BasketItemRepository(_context);

        public IProductCommentRepository ProductCommentRepository => _productCommentRepository ?? new ProductCommentRepository(_context);

        public IOrderRepository OrderRepository => _orderRepository ?? new OrderRepository(_context);

        public IOrderItemRepository OrderItemRepository => _orderItemRepository ?? new OrderItemRepository(_context);

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
