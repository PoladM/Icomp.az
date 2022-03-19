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
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IComp.Service.Interfaces
{
    public interface IProductService
    {
        Task<ProductGetDTO> CreateAsync(ProductPostDto postDTO);
        PaginatedListDto<ProductListItemDto> GetAllProd(int? pagesize, int page);
        PaginatedListDto<ProductListItemDto> FilterProd(int? processorserieid, int? videocardserieid, int? motherboardid, int? prodtypeid, int? prodmemoryid, int? brandid, int? destinationid, int? harddiscid, int? categoryid, int? pagesize, int page);

        List<ProcessorGetDto> GetProcessors();
        List<CategoryGetDto> GetCategories();
        List<BrandGetDto> GetBrands();
        List<HardDiscGetDto> GetHardDiscs();
        List<MemoryGetDto> GetMemories();
        List<MotherBoardGetDto> GetMotherBoards();
        List<VideoCardGetDto> GetVideoCards();
        List<ProdTypeGetDto> GetProdTypes();
        List<DestinationGetDto> GetDestinations();

        List<ProcessorSerieGetDto> GetProcessirSeries();
        List<HardDiscCapacityGetDto> GetHardDiscCapacities();
        List<MCapacityGetDto> GetMemoryCapacities();
        List<VCSerieGetDto> GetVideoCardSeries();
        

        
        Task UpdateAsync(int id, ProductPostDto postDTO);
        Task DeleteAsync(int id);
        Task RestoreAsync(int id);
        Task<ProductPostDto> GetByIdAsync(int id);
    }
}
