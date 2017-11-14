using System;
using System.Linq;
using WareHouseHelper.DataAccess.Models;

namespace WareHouseHelper.DataAccess.Repositories.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>, IRepository
    {
        IQueryable<Product> GetShopProducts();
    }
}