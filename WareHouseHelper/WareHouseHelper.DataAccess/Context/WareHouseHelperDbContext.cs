using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WareHouseHelper.DataAccess.Models;

namespace WareHouseHelper.DataAccess.Context
{
    public class WareHouseHelperDbContext : DbContext, IWareHouseHelperDbContext
    {
        public WareHouseHelperDbContext()
        {
        }

        public WareHouseHelperDbContext(DbContextOptions<WareHouseHelperDbContext> option) : base(option)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=WareHouseHelper; Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            modelBuilder.Entity<ProductType>().HasIndex(u => u.Name).IsUnique();
        }

        public new DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }

        public void SetModified(object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }

        public void PerformMigration()
        {
            Database.Migrate();
        }

        #region DbSet

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }

        #endregion DbSet
    }
}