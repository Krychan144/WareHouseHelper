using WareHouseHelper.DataAccess.Context;
using WareHouseHelper.DataAccess.Models;
using WareHouseHelper.DataAccess.Repositories.Interfaces;

namespace WareHouseHelper.DataAccess.Repositories.Implementations
{
    public class ShopRepository : GenericRepository<Shop>, IShopRepository
    {
        public ShopRepository(IWareHouseHelperDbContext context)
            : base(context)
        {
        }
    }
}