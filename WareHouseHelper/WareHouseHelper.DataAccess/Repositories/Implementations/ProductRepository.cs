using System;
using System.Linq;
using WareHouseHelper.DataAccess.Context;
using WareHouseHelper.DataAccess.Models;
using WareHouseHelper.DataAccess.Repositories.Interfaces;

namespace WareHouseHelper.DataAccess.Repositories.Implementations
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(IWareHouseHelperDbContext context)
            : base(context)
        {
        }

        public IQueryable<Product> GetShopProducts()
        {
            var query = from product in context.Set<Product>()
                        join productType in context.Set<ProductType>() on product.ProductType.Id equals productType.Id
                        join shop in context.Set<Shop>() on product.Shop.Id equals shop.Id
                        where product.DeletedOn == null
                        select new Product
                        {
                            Id = product.Id,
                            Expense = product.Expense,
                            ProductType = new ProductType
                            {
                                Id = productType.Id,
                                Name = productType.Name
                            },
                            Name = product.Name,
                            Shop = new Shop
                            {
                                Id = shop.Id,
                                Name = shop.Name
                            }
                        };

            return !(query.Count() > 0) ? Enumerable.Empty<Product>().AsQueryable() : query;
        }
    }
}