using AutoMapper;
using IComp.Core;
using IComp.Core.Entities;
using IComp.Data;
using IComp.Service.DTOs;
using IComp.Service.DTOs.BrandDTOs;
using IComp.Service.DTOs.CategoryDTOs;
using IComp.Service.DTOs.ColorDTOs;
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
using IComp.Service.DTOs.SoftwareDTOs;
using IComp.Service.DTOs.VCSerieDTOs;
using IComp.Service.DTOs.VideoCardDTOs;
using IComp.Service.Exceptions;
using IComp.Service.Interfaces;
using IComp.Service.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<AppUser> _userManager;


        public ProductService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public ProductService()
        {
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

        public PaginatedListDto<ProductListItemDto> GetAllProd(int page)
        {
            var query = _unitOfWork.ProductRepository.GetAll();

            var pageSize = 3;

            List<ProductListItemDto> items = query.Skip((page - 1) * pageSize).Take(pageSize).Select(x => new ProductListItemDto { Id = x.Id, Name = x.Name, Count = x.Count, IsDeleted = x.IsDeleted, ProductImages = x.ProductImages, Price = x.SalePrice, Processor = x.Processor, HardDisc = x.HardDisc, Brand = x.Brand, Category = x.Category, Destination = x.Destination, MotherBoard = x.MotherBoard, ProdMemory = x.ProdMemory, VideoCard = x.VideoCard }).ToList();

            var listDto = new PaginatedListDto<ProductListItemDto>(items, query.Count(), page, pageSize);

            return listDto;
        }

        public PaginatedListDto<ProductListItemDto> FilterProd(decimal? minprice, decimal? maxprice, string sort, int? processorserieid, int? videocardserieid, int? motherboardid, int? prodtypeid, int? prodmemorycapacityid, int? brandid, int? destinationid, int? harddiscapacitycid, int? categoryid, int? pagesize, int page)
        {
            var query = _unitOfWork.ProductRepository.GetAll("Processor.ProcessorSerie", "VideoCard.VideoCardSerie", "MotherBoard", "ProdType", "ProdMemory.MemoryCapacity", "Brand", "Destination", "HardDisc.HDDCapacity");

            if (processorserieid != null)
            {
                query = _unitOfWork.ProductRepository.Filter(query, x => x.Processor.ProcessorSerieId == processorserieid);
            }
            if (videocardserieid != null)
            {
                query = _unitOfWork.ProductRepository.Filter(query, x => x.VideoCard.VideoCardSerieId == videocardserieid);
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
                case "name_asc":
                    query = _unitOfWork.ProductRepository.FilterByNameAsc(query, sort);
                    break;
                case "name_desc":
                    query = _unitOfWork.ProductRepository.FilterByNameAsc(query, sort);
                    break;
                default:
                    break;
            }

            if (minprice != null && maxprice != null)
                query = query.Where(x => x.SalePrice >= minprice && x.SalePrice <= maxprice);

            var pageSize = pagesize ?? 3;

            List<ProductListItemDto> items = query.Skip((page - 1) * pageSize).Take(pageSize).Select(x => new ProductListItemDto { Id = x.Id, Name = x.Name, Count = x.Count, IsDeleted = x.IsDeleted, ProductImages = x.ProductImages, Price = x.SalePrice, Processor = x.Processor, HardDisc = x.HardDisc, Brand = x.Brand, Category = x.Category, Destination = x.Destination, MotherBoard = x.MotherBoard, ProdMemory = x.ProdMemory, VideoCard = x.VideoCard }).ToList();

            var listDto = new PaginatedListDto<ProductListItemDto>(items, query.Count(), page, pageSize);

            return listDto;
        }

        public decimal FilterByPrice(string val)
        {
            if (val == "max")
                return _unitOfWork.ProductRepository.FilterByPriceRange("max");
            else if (val == "min")
                return _unitOfWork.ProductRepository.FilterByPriceRange("min");
            return 0;
        }

        public async Task<ProductPostDto> GetByIdAsync(int id)
        {
            var product = await _unitOfWork.ProductRepository.GetAsync(x => x.Id == id, "ProductImages");

            if (product == null)
            {
                throw new ItemNotFoundException("Item not Found");
            }

            return _mapper.Map<ProductPostDto>(product);
        }
        public async Task<DetailViewModel> FindByIdAsync(int id)
        {
            var existProduct = await _unitOfWork.ProductRepository.GetAsync(x => x.Id == id, "Processor.ProcessorSerie", "VideoCard.VideoCardSerie", "MotherBoard", "ProdType", "ProdMemory.MemoryCapacity", "Brand", "Destination", "HardDisc.HDDCapacity", "Category", "Color", "Software", "ProductImages", "ProductComments");
            
            if (existProduct == null)
            {
                throw new ItemNotFoundException("Item not found");
            }

            var productDto = _mapper.Map<ProductGetDTO>(existProduct);

            var viewModel = new DetailViewModel
            {
                Product = productDto,
                Comment = new ProductComment { ProductId = id }
            };

            return viewModel;
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

        public async Task UpdateAsync(int id, ProductPostDto postDto)
        {
            var existProduct = await _unitOfWork.ProductRepository.GetAsync(x => x.Id == id && !x.IsDeleted);

            if (existProduct == null)
            {
                throw new ItemNotFoundException("Item not found or deleted");
            }
            if (await _unitOfWork.ProductRepository.IsExistAsync(x => x.Id != id && x.Name.ToLower().Trim() == postDto.Name.ToLower().Trim() && !x.IsDeleted))
            {
                throw new RecordDuplicatedException("ModelName already exist with name " + postDto.Name);
            }

            existProduct.ProcessorId = postDto.ProcessorId;
            existProduct.CategoryId = postDto.CategoryId;
            existProduct.BrandId = postDto.BrandId;
            existProduct.DestinationId = postDto.DestinationId;
            existProduct.HardDiscId = postDto.HardDiscId;
            existProduct.ProdMemoryId = postDto.ProdMemoryId;
            existProduct.MotherBoardId = postDto.MotherBoardId;
            existProduct.ProdTypeId = postDto.ProdTypeId;
            existProduct.VideoCardId = postDto.VideoCardId;
            existProduct.ColorId = postDto.ColorId;
            existProduct.SoftwareId = postDto.SoftwareId;
            existProduct.Name = postDto.Name;
            existProduct.SalePrice = postDto.SalePrice;
            existProduct.CostPrice = postDto.CostPrice;
            existProduct.DiscountPercent = postDto.DiscountPercent;
            existProduct.Count = postDto.Count;
            existProduct.IsAvailable = postDto.IsAvailable;
            existProduct.IsNew = postDto.IsNew;
            existProduct.IsFeatured = postDto.IsFeatured;
            existProduct.IsPopular = postDto.IsPopular;
            existProduct.HasBluetooth = postDto.HasBluetooth;
            existProduct.HasWifi = postDto.HasWifi;
            existProduct.SoundType = postDto.SoundType;
            existProduct.InputPorts = postDto.InputPorts;
            existProduct.USB = postDto.USB;
            existProduct.USBTypeC = postDto.USBTypeC;
            existProduct.Network = postDto.Network;
            existProduct.PowerSupply = postDto.PowerSupply;
            existProduct.Weight = postDto.Weight;
            existProduct.WarrantyPeriod = postDto.WarrantyPeriod;
            existProduct.ProductImages = postDto.ProductImages;

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

        public List<ColorGetDto> GetColors()
        {
            var colors = _unitOfWork.ColorRepository.GetAll().ToList();

            var colorGetDtos = _mapper.Map<List<ColorGetDto>>(colors);
            return colorGetDtos;
        }

        public List<SoftwareGetDto> GetSoftwares()
        {
            var softwares = _unitOfWork.SoftWareRepository.GetAll().ToList();

            var softwareGetDtos = _mapper.Map<List<SoftwareGetDto>>(softwares);
            return softwareGetDtos;
        }

        public async Task<ProductImage> GetProductImage(int id)
        {
            var productImage = await _unitOfWork.ProductImageRepository.GetAsync(x => x.Id == id);

            if (productImage == null)
            {
                throw new ItemNotFoundException("Item not Found");
            }

            return productImage;
        }

        public async Task DeleteProductImage(ProductImage productImage)
        {
            _unitOfWork.ProductImageRepository.Remove(productImage);

            await _unitOfWork.CommitAsync();
        }

        public Dictionary<string, string> GetSettings()
        {
            var settings = _unitOfWork.SettingRepository.GetAll().ToDictionary(x => x.Key, x => x.Value);
            
            return settings;
        }


        public async Task<CommonBasketViewModel> _getBasket(List<BasketCookieItemViewModel> basketItems)
        {

            CommonBasketViewModel basketVM = new CommonBasketViewModel
            {
                BasketItems = new List<BasketProductViewModel>(),
                TotalPrice = 0
            };


            foreach (var item in basketItems)
            {
                var product = await _unitOfWork.ProductRepository.GetAsync(x => x.Id == item.ProductId, "ProductImages");

                BasketProductViewModel basketBook = new BasketProductViewModel
                {
                    Product = product,
                    Count = item.Count
                };

                basketVM.BasketItems.Add(basketBook);
                decimal totalPrice = product.DiscountPercent > 0 ? (product.SalePrice * (1 - product.DiscountPercent / 100)) : product.SalePrice;
                basketVM.TotalPrice += totalPrice * item.Count;
            }

            return basketVM;
        }

        public async Task<CommonBasketViewModel> _getBasket(List<BasketItem> cardItems)
        {
            CommonBasketViewModel cardVM = new CommonBasketViewModel
            {
                BasketItems = new List<BasketProductViewModel>(),
                TotalPrice = 0
            };

            foreach (var item in cardItems)
            {
                Product product = await _unitOfWork.ProductRepository.GetAsync(x => x.Id == item.ProductId, "ProductImages");
                BasketProductViewModel basketProductVM = new BasketProductViewModel
                {
                    Product = product,
                    Count = item.Count
                };

                cardVM.BasketItems.Add(basketProductVM);
                decimal totalPrice = product.DiscountPercent > 0 ? (product.SalePrice * (1 - product.DiscountPercent / 100)) : product.SalePrice;
                cardVM.TotalPrice += totalPrice * item.Count;
            }
            return cardVM;
        }

        public async Task<bool> AnyProd(int id)
        {
            return await _unitOfWork.ProductRepository.IsExistAsync(x => x.Id == id && !x.IsDeleted);
        }

        public async Task<List<BasketItem>> UserBasket(int id, AppUser appUser)
        {
            BasketItem item = await _unitOfWork.BasketItemRepository.GetAsync(x => x.AppUserId == appUser.Id && x.ProductId == id);

            if (item == null)
            {
                item = new BasketItem
                {
                    AppUserId = appUser.Id,
                    ProductId = id,
                    CreatedAt = DateTime.UtcNow.AddHours(4),
                    Count = 1
                };
                await _unitOfWork.BasketItemRepository.AddAsync(item);
            }
            else
            {
                item.Count++;
            }
            await _unitOfWork.CommitAsync();

            var items = _unitOfWork.BasketItemRepository.GetAll(x => x.AppUserId == appUser.Id).ToList();
            return items;
        }

        public async Task<CommonBasketViewModel> DeleteBasket(int id)
        {
            if (!await AnyProd(id))
            {
                throw new ItemNotFoundException("Item not found");
            }

            AppUser appUser = null;

            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                appUser = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == _httpContextAccessor.HttpContext.User.Identity.Name && !x.IsAdmin);
            }

            if (appUser == null)
            {
                string cookie = _httpContextAccessor.HttpContext.Request.Cookies["basket"];
                List<BasketCookieItemViewModel> cookieItems = new List<BasketCookieItemViewModel>();

                if (!string.IsNullOrWhiteSpace(cookie))
                {
                    cookieItems = JsonConvert.DeserializeObject<List<BasketCookieItemViewModel>>(cookie);
                }

                BasketCookieItemViewModel cookieItem = cookieItems.FirstOrDefault(x => x.ProductId == id);


                if (cookieItem.Count > 1)
                {
                    cookieItem.Count--;
                }
                else
                {
                    cookieItems.Remove(cookieItem);
                }

                cookie = JsonConvert.SerializeObject(cookieItems);
                _httpContextAccessor.HttpContext.Response.Cookies.Append("basket", cookie);

                return await _getBasket(cookieItems);
            }
            else
            {
                BasketItem item = await _unitOfWork.BasketItemRepository.GetAsync(x => x.AppUserId == appUser.Id && x.ProductId == id);


                if (item.Count > 1)
                {
                    item.Count--;
                }
                else
                {
                    _unitOfWork.BasketItemRepository.Remove(item);
                }
                await _unitOfWork.CommitAsync();

                var items = _unitOfWork.BasketItemRepository.GetAll(x => x.AppUserId == appUser.Id).ToList();
                return await _getBasket(items);
            }
        }

        public async Task<List<Product>> SearchProd(string searchString)
        {
            var products = _unitOfWork.ProductRepository.GetAll("ProductImages");

            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.Name.Trim().ToLower().Contains(searchString));
            }
            else
            {
                products = null;
            }
            

            return await products.ToListAsync();
        }

        public async Task<int> Comment(ProductComment comment)
        {
            AppUser appUser = null;
            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                appUser = _userManager.Users.FirstOrDefault(x => x.UserName == _httpContextAccessor.HttpContext.User.Identity.Name && !x.IsAdmin);
            }


            var product = await _unitOfWork.ProductRepository.GetAsync(x => x.Id == comment.ProductId, "ProductComments");
            if (product == null)
            {
                throw new ItemNotFoundException("Item not found");
            }

            //if (appUser == null)
            //{
            //    comment.CreatedAt = DateTime.UtcNow.AddHours(4);
            //    await _unitOfWork.ProductCommentRepository.AddAsync(comment);
            //    await _unitOfWork.CommitAsync();
            //    var sum = product.ProductComments.Sum(x => x.Rate);
            //    var rate = Math.Ceiling( sum / (double)product.ProductComments.Count);
            //    product.Rate = (int)rate;
            //    await _unitOfWork.CommitAsync();
            //    return comment.ProductId;
            //}
            //comment.AppUserId = appUser.Id;
            //comment.CreatedAt = DateTime.UtcNow.AddHours(4);
            await _unitOfWork.ProductCommentRepository.AddAsync(comment);
            product.Rate = (int)Math.Ceiling(product.ProductComments.Sum(x => x.Rate) / (double)product.ProductComments.Count);
            await _unitOfWork.CommitAsync();
            return comment.ProductId;
        }
    }
}
