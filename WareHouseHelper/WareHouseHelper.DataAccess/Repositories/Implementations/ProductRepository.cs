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
    }
}