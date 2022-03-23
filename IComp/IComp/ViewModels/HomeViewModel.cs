using IComp.Service.DTOs;
using IComp.Service.DTOs.BrandDTOs;
using IComp.Service.DTOs.ProductDTOs;
using System.Collections.Generic;

namespace IComp.ViewModels
{
    public class HomeViewModel
    {
        public PaginatedListDto<ProductListItemDto> Paginated { get; set; }
        public List<BrandGetDto> Brands { get; set; }
    }
}
