using WareHouseHelper.DataAccess.Context;
using WareHouseHelper.DataAccess.Models;
using WareHouseHelper.DataAccess.Repositories.Interfaces;

namespace WareHouseHelper.DataAccess.Repositories.Implementations
{
    public class ProductTypeRepository : GenericRepository<ProductType>, IProductTypeRepository
    {
        public ProductTypeRepository(IWareHouseHelperDbContext context)
            : base(context)
        {
        }
    }
}