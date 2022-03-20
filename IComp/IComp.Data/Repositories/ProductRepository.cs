using IComp.Core.Entities;
using IComp.Core.Repositories;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace IComp.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private StoreDbContext _context;
        public ProductRepository(StoreDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Product> Filter(IQueryable<Product> query, Expression<Func<Product, bool>> exp)
        {
            return query.Where(exp);
        }
        public IQueryable<Product> FilterByPrice(IQueryable<Product> query, string AscOrDesc)
        {
            if (AscOrDesc == "price_low")
            {
                return query.OrderByDescending(x => x.Price);
            }
            else
            {
                return query.OrderBy(x => x.Price);
            }
        }
    }
}
