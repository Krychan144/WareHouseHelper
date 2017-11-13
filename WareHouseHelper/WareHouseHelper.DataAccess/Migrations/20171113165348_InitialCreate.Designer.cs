using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WareHouseHelper.DataAccess.Context;

namespace WareHouseHelper.DataAccess.Migrations
{
    [DbContext(typeof(WareHouseHelperDbContext))]
    [Migration("20171113165348_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WareHouseHelper.DataAccess.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<DateTime?>("DeletedOn");

                    b.Property<decimal>("Expense")
                        .HasColumnType("DECIMAL(16,2)");

                    b.Property<DateTime>("ModifiedOn");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(100)");

                    b.Property<Guid>("ProductTypeId");

                    b.Property<int>("Quantity");

                    b.Property<Guid>("ShopId");

                    b.HasKey("Id");

                    b.HasIndex("ProductTypeId");

                    b.HasIndex("ShopId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("WareHouseHelper.DataAccess.Models.ProductType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<DateTime?>("DeletedOn");

                    b.Property<DateTime>("ModifiedOn");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(100)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("ProductTypes");
                });

            modelBuilder.Entity("WareHouseHelper.DataAccess.Models.Shop", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(100)");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<DateTime?>("DeletedOn");

                    b.Property<DateTime>("ModifiedOn");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(100)");

                    b.Property<decimal>("Phone")
                        .HasColumnType("DECIMAL(11,0)");

                    b.HasKey("Id");

                    b.ToTable("Shops");
                });

            modelBuilder.Entity("WareHouseHelper.DataAccess.Models.Product", b =>
                {
                    b.HasOne("WareHouseHelper.DataAccess.Models.ProductType", "ProductType")
                        .WithMany()
                        .HasForeignKey("ProductTypeId");

                    b.HasOne("WareHouseHelper.DataAccess.Models.Shop", "Shop")
                        .WithMany("Products")
                        .HasForeignKey("ShopId");
                });
        }
    }
}
