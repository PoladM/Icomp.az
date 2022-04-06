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
            query = query.Where(exp);

            return query;
        }

        public IQueryable<Product> FilterByNameAsc(IQueryable<Product> query, string AscOrDesc)
        {
            if (AscOrDesc == "name_asc")
            {
                return query.OrderBy(x => x.Name);
            }
            return query.OrderByDescending(x => x.Name);
        }

        public IQueryable<Product> FilterByPrice(IQueryable<Product> query, string AscOrDesc)
        {
            if (AscOrDesc == "price_low")
            {
                return query.OrderByDescending(x => x.SalePrice);
            }
            else
            {
                return query.OrderBy(x => x.SalePrice);
            }
        }

        public decimal FilterByPriceRange(string val)
        {
            var products = _context.Products;
            if (products.Any())
            {
                if (val == "max")
                {
                    return products.Max(x => x.SalePrice);
                }
                else if (val == "min")
                {
                    return products.Min(x => x.SalePrice);
                }
            }
            return 0;
        }
    }
}
