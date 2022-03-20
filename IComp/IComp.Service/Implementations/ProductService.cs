using AutoMapper;
using IComp.Core;
using IComp.Core.Entities;
using IComp.Data;
using IComp.Service.DTOs;
using IComp.Service.DTOs.BrandDTOs;
using IComp.Service.DTOs.CategoryDTOs;
using IComp.Service.DTOs.DestinationDTOs;
using IComp.Service.DTOs.HardDiscCapacityDTOs;
using IComp.Service.DTOs.HardDiscDTOs;
using IComp.Service.DTOs.MemoryCapacityDTOs;
using IComp.Service.DTOs.MemoryDTOs;
using IComp.Service.DTOs.MotherBoardDTOs;
using IComp.Service.DTOs.ProcessorDTOs;
using IComp.Service.DTOs.ProcessorSerieDTOs;
using IComp.Service.DTOs.ProdTypeDTOs;
using IComp.Service.DTOs.ProductDTOs;
using IComp.Service.DTOs.VCSerieDTOs;
using IComp.Service.DTOs.VideoCardDTOs;
using IComp.Service.Exceptions;
using IComp.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IComp.Service.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ProductGetDTO> CreateAsync(ProductPostDto postDTO)
        {
            if (await _unitOfWork.MemoryRepository.IsExistAsync(x => x.ModelName.ToLower().Trim() == postDTO.Name.ToLower().Trim() && !x.IsDeleted))
            {
                throw new RecordDuplicatedException("ModelName already exist with name " + postDTO.Name);
            }


            Product product = _mapper.Map<Product>(postDTO);

            await _unitOfWork.ProductRepository.AddAsync(product);
            await _unitOfWork.CommitAsync();

            return new ProductGetDTO
            {
                Id = product.Id,
                Name = product.Name
            };
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _unitOfWork.ProductRepository.GetAsync(x => x.Id == id && !x.IsDeleted);

            if (product == null)
            {
                throw new ItemNotFoundException("Item not found");
            }

            product.IsDeleted = true;
            product.IsAvailable = false;
            await _unitOfWork.CommitAsync();
        }

        public PaginatedListDto<ProductListItemDto> GetAllProd( int page)
        {
            var query = _unitOfWork.ProductRepository.GetAll();

            var pageSize = 3;

            List<ProductListItemDto> items = query.Skip((page - 1) * pageSize).Take(pageSize).Select(x => new ProductListItemDto { Id = x.Id, Name = x.Name, Count = x.Count, IsDeleted = x.IsDeleted, ProductImages = x.ProductImages, Price = x.Price, Processor = x.Processor, HardDisc = x.HardDisc, Brand = x.Brand, Category = x.Category, Destination = x.Destination, MotherBoard = x.MotherBoard, ProdMemory = x.ProdMemory, VideoCard = x.VideoCard }).ToList();

            var listDto = new PaginatedListDto<ProductListItemDto>(items, query.Count(), page, pageSize);

            return listDto;
        }

        public PaginatedListDto<ProductListItemDto> FilterProd(string sort, int? processorserieid, int? videocardserieid, int? motherboardid, int? prodtypeid, int? prodmemorycapacityid, int? brandid, int? destinationid, int? harddiscapacitycid, int? categoryid, int? pagesize, int page)
        {
            var query = _unitOfWork.ProductRepository.GetAll("Processor.ProcessorSerie", "VideoCard.VideoCardSerie", "MotherBoard", "ProdType", "ProdMemory.MemoryCapacity", "Brand", "Destination", "HardDisc.HDDCapacity");

            if (processorserieid != null)
            {
                query = _unitOfWork.ProductRepository.Filter(query, x => x.Processor.ProcessorSerieId == processorserieid);
            }
            if (videocardserieid != null)
            {
                query = _unitOfWork.ProductRepository.Filter(query, x => x.VideoCardId == videocardserieid);
            }
            if (motherboardid != null)
            {
                query = _unitOfWork.ProductRepository.Filter(query, x => x.MotherBoardId == motherboardid);
            }
            if (destinationid != null)
            {
                query = _unitOfWork.ProductRepository.Filter(query, x => x.DestinationId == destinationid);
            }
            if (prodtypeid != null)
            {
                query = _unitOfWork.ProductRepository.Filter(query, x => x.ProdTypeId == prodtypeid);
            }
            if (prodmemorycapacityid != null)
            {
                query = _unitOfWork.ProductRepository.Filter(query, x => x.ProdMemory.MemoryCapacityId == prodmemorycapacityid);
            }
            if (brandid != null)
            {
                query = _unitOfWork.ProductRepository.Filter(query, x => x.BrandId == brandid);
            }
            if (brandid != null)
            {
                query = _unitOfWork.ProductRepository.Filter(query, x => x.BrandId == brandid);
            }
            if (harddiscapacitycid != null)
            {
                query = _unitOfWork.ProductRepository.Filter(query, x => x.HardDisc.HDDCapacityId == harddiscapacitycid);
            }
            if (categoryid != null)
            {
                query = _unitOfWork.ProductRepository.Filter(query, x => x.CategoryId == categoryid);
            }

            switch (sort)
            {
                case "price_high":
                    query = _unitOfWork.ProductRepository.FilterByPrice(query, sort);
                    break;
                case "price_low":
                    query = _unitOfWork.ProductRepository.FilterByPrice(query, sort);
                    break;
                default:
                    break;
            }


            var pageSize = pagesize ?? 3;

            List<ProductListItemDto> items = query.Skip((page - 1) * pageSize).Take(pageSize).Select(x => new ProductListItemDto { Id = x.Id, Name = x.Name, Count = x.Count, IsDeleted = x.IsDeleted, ProductImages = x.ProductImages, Price = x.Price, Processor = x.Processor, HardDisc = x.HardDisc, Brand = x.Brand, Category = x.Category, Destination = x.Destination, MotherBoard = x.MotherBoard, ProdMemory = x.ProdMemory, VideoCard = x.VideoCard }).ToList();

            var listDto = new PaginatedListDto<ProductListItemDto>(items, query.Count(), page, pageSize);

            return listDto;
        }


        public async Task<ProductPostDto> GetByIdAsync(int id)
        {
            var product = await _unitOfWork.ProductRepository.GetAsync(x => x.Id == id);

            if (product == null)
            {
                throw new ItemNotFoundException("Item not Found");
            }

            return _mapper.Map<ProductPostDto>(product);
        }
        public List<BrandGetDto> GetBrands()
        {
            var brands = _unitOfWork.BrandRepository.GetAll().ToList();

            var brandsDto = _mapper.Map<List<BrandGetDto>>(brands);
            return brandsDto;
        }

        public List<CategoryGetDto> GetCategories()
        {
            var categories = _unitOfWork.CategoryRepository.GetAll().ToList();

            var categoryGetDtos = _mapper.Map<List<CategoryGetDto>>(categories);
            return categoryGetDtos;
        }

        public List<HardDiscGetDto> GetHardDiscs()
        {
            var hardDiscs = _unitOfWork.HardDiscRepository.GetAll().ToList();

            var hardDiscGetDtos = _mapper.Map<List<HardDiscGetDto>>(hardDiscs);
            return hardDiscGetDtos;
        }

        public List<MemoryGetDto> GetMemories()
        {
            var memories = _unitOfWork.MemoryRepository.GetAll().ToList();

            var memoryGetDtos = _mapper.Map<List<MemoryGetDto>>(memories);
            return memoryGetDtos;
        }

        public List<MotherBoardGetDto> GetMotherBoards()
        {
            var motherBoards = _unitOfWork.MotherBoardRepository.GetAll().ToList();

            var motherBoardGetDtos = _mapper.Map<List<MotherBoardGetDto>>(motherBoards);
            return motherBoardGetDtos;
        }

        public List<ProcessorGetDto> GetProcessors()
        {
            var processors = _unitOfWork.ProcessorRepository.GetAll().ToList();

            var processorGetDtos = _mapper.Map<List<ProcessorGetDto>>(processors);
            return processorGetDtos;
        }

        public List<VideoCardGetDto> GetVideoCards()
        {
            var videoCards = _unitOfWork.VideoCardRepository.GetAll().ToList();

            var videoCardGetDtos = _mapper.Map<List<VideoCardGetDto>>(videoCards);
            return videoCardGetDtos;
        }

        public List<ProdTypeGetDto> GetProdTypes()
        {
            var prodTypes = _unitOfWork.ProdTypeRepository.GetAll().ToList();

            var prodTypeGetDtos = _mapper.Map<List<ProdTypeGetDto>>(prodTypes);
            return prodTypeGetDtos;
        }

        public List<DestinationGetDto> GetDestinations()
        {
            var destinations = _unitOfWork.DestinationRepository.GetAll().ToList();

            var destinationGetDtos = _mapper.Map<List<DestinationGetDto>>(destinations);
            return destinationGetDtos;
        }
        public async Task RestoreAsync(int id)
        {
            var product = await _unitOfWork.ProductRepository.GetAsync(x => x.Id == id && x.IsDeleted);

            if (product == null)
            {
                throw new ItemNotFoundException("Item not found");
            }

            product.IsDeleted = false;
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(int id, ProductPostDto postDTO)
        {
            var existProd = await _unitOfWork.ProductRepository.GetAsync(x => x.Id == id && !x.IsDeleted);

            if (existProd == null)
            {
                throw new ItemNotFoundException("Item not found or deleted");
            }
            if (await _unitOfWork.ProductRepository.IsExistAsync(x => x.Id != id && x.Name.ToLower().Trim() == postDTO.Name.ToLower().Trim() && !x.IsDeleted))
            {
                throw new RecordDuplicatedException("ModelName already exist with name " + postDTO.Name);
            }

            existProd.Name = postDTO.Name;
            existProd.Price = postDTO.Price;
            existProd.Count = postDTO.Count;
            existProd.IsAvailable = postDTO.IsAvailable;

            await _unitOfWork.CommitAsync();
        }

        public List<ProcessorSerieGetDto> GetProcessirSeries()
        {
            var proc = _unitOfWork.ProcessorSerieRepository.GetAll().ToList();

            var processorGets = _mapper.Map<List<ProcessorSerieGetDto>>(proc);
            return processorGets;
        }

        public List<HardDiscCapacityGetDto> GetHardDiscCapacities()
        {
            var capac = _unitOfWork.HardDiscCapacityRepository.GetAll().ToList();

            var capacityGetDtos = _mapper.Map<List<HardDiscCapacityGetDto>>(capac);
            return capacityGetDtos;
        }

        public List<MCapacityGetDto> GetMemoryCapacities()
        {
            var memoryCapacities = _unitOfWork.MemoryCapacityRepository.GetAll().ToList();

            var capacityGetDtos = _mapper.Map<List<MCapacityGetDto>>(memoryCapacities);
            return capacityGetDtos;
        }

        public List<VCSerieGetDto> GetVideoCardSeries()
        {
            var series = _unitOfWork.VCSerieRepository.GetAll().ToList();

            var serieGetDtos = _mapper.Map<List<VCSerieGetDto>>(series);
            return serieGetDtos;
        }
    }
}
