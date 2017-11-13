using Microsoft.EntityFrameworkCore;
using WareHouseHelper.DataAccess.Models;
using WareHouseHelper.DataAccess.Repositories.Interfaces;

namespace WareHouseHelper.DataAccess.Context
{
    public interface IWareHouseHelperDbContext : IRepository
    {
        int SaveChanges();

        DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;

        void SetModified(object entity);

        void PerformMigration();
    }
}