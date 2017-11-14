using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using MimeKit;
using WareHouseHelper.BusinesLogic.Models;
using WareHouseHelper.DataAccess.Models;

namespace WareHouseHelper.BusinesLogic.Configuration.Implementations
{
    public class AutoMapperBulider
    {
        public static void Build()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<ProductModel, Product>().MaxDepth(1);
                config.CreateMap<Product, ProductModel>().MaxDepth(1);

                config.CreateMap<ShopModel, Shop>().MaxDepth(1);
                config.CreateMap<Shop, ShopModel>().MaxDepth(1);

                config.CreateMap<ProductTypeModel, ProductType>().MaxDepth(1);
                config.CreateMap<ProductType, ProductTypeModel>().MaxDepth(1);

                config.CreateMissingTypeMaps = true;
            });
        }
    }
}