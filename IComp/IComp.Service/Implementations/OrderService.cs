using IComp.Core;
using IComp.Core.Entities;
using IComp.Service.DTOs;
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
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<PaginatedListDto<Order>> GetAll(int page)
        {
            var query = _unitOfWork.OrderRepository.GetAll();
            int pageSize = 3;

            List<Order> items = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            var listDto = new PaginatedListDto<Order>(items, query.Count(), page, pageSize);

            return listDto;
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            var existOrder = await _unitOfWork.OrderRepository.GetAsync(x => x.Id == id);
            if(existOrder == null) { throw new ItemNotFoundException("Item not found"); }
            return existOrder;
        }

        public async Task UpdateAsync(Order order)
        {
            var existOrder = await GetByIdAsync(order.Id);
            existOrder.Status = order.Status;
            await _unitOfWork.CommitAsync();
        }
    }
}
