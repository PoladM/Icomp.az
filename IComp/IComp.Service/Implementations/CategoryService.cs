using AutoMapper;
using IComp.Core;
using IComp.Core.Entities;
using IComp.Service.DTOs;
using IComp.Service.DTOs.CategoryDTOs;
using IComp.Service.Exceptions;
using IComp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IComp.Service.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<CategoryGetDto> CreateAsync(CategoryPostDto postDTO)
        {
            if (await _unitOfWork.CategoryRepository.IsExistAsync(x => x.Name.ToLower().Trim() == postDTO.Name.ToLower().Trim() && !x.IsDeleted))
            {
                throw new RecordDuplicatedException("ModelName already exist with name " + postDTO.Name);
            }

            Category category = _mapper.Map<Category>(postDTO);

            await _unitOfWork.CategoryRepository.AddAsync(category);
            await _unitOfWork.CommitAsync();

            return new CategoryGetDto
            {
                Id = category.Id,
                Name = category.Name
            };
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _unitOfWork.CategoryRepository.GetAsync(x => x.Id == id && !x.IsDeleted);

            if (category == null)
            {
                throw new ItemNotFoundException("Item not found");
            }

            category.IsDeleted = true;
            await _unitOfWork.CommitAsync();
        }

        public PaginatedListDto<CategoryListItemDto> GetAllProd(int page)
        {
            var query = _unitOfWork.CategoryRepository.GetAll();
            int pageSize = 3;

            List<CategoryListItemDto> items = query.Skip((page - 1) * pageSize).Take(pageSize).Select(x => new CategoryListItemDto { Id = x.Id, Name = x.Name, ProductsCount = x.Products.Count, IsDeleted = x.IsDeleted }).ToList();

            var listDto = new PaginatedListDto<CategoryListItemDto>(items, query.Count(), page, pageSize);

            return listDto;
        }

        public async Task<CategoryPostDto> GetByIdAsync(int id)
        {
            var category = await _unitOfWork.CategoryRepository.GetAsync(x => x.Id == id);

            if (category == null)
            {
                throw new ItemNotFoundException("Item not Found");
            }

            return _mapper.Map<CategoryPostDto>(category);
        }

        public async Task RestoreAsync(int id)
        {
            var category = await _unitOfWork.CategoryRepository.GetAsync(x => x.Id == id && x.IsDeleted);

            if (category == null)
            {
                throw new ItemNotFoundException("Item not found");
            }

            category.IsDeleted = false;
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(int id, CategoryPostDto postDTO)
        {
            var existProd = await _unitOfWork.CategoryRepository.GetAsync(x => x.Id == id && !x.IsDeleted);

            if (existProd == null)
            {
                throw new ItemNotFoundException("Item not found or deleted");
            }
            if (await _unitOfWork.CategoryRepository.IsExistAsync(x => x.Id != id && x.Name.ToLower().Trim() == postDTO.Name.ToLower().Trim() && !x.IsDeleted))
            {
                throw new RecordDuplicatedException("ModelName already exist with name " + postDTO.Name);
            }

            existProd.Name = postDTO.Name;
    
            await _unitOfWork.CommitAsync();
        }
    }
}
