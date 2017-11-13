using WareHouseHelper.BusinesLogic.Configuration.Interfaces;
using WareHouseHelper.DataAccess.Context;

namespace WareHouseHelper.BusinesLogic.Configuration.Implementations
{
    public class MigrationHelper : IMigrationHelper
    {
        private readonly IWareHouseHelperDbContext _dbContext;

        public MigrationHelper(IWareHouseHelperDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Migrate()
        {
            _dbContext.PerformMigration();
        }
    }
}