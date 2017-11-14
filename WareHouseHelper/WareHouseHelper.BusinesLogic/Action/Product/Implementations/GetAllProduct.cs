using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WareHouseHelper.BusinesLogic.Action.Product.Interfaces;
using WareHouseHelper.BusinesLogic.Models;
using WareHouseHelper.DataAccess.Repositories.Interfaces;

namespace WareHouseHelper.BusinesLogic.Action.Product.Implementations
{
    public class GetAllProduct : IGetAllProducts
    {
        private readonly IProductRepository _productRepository;

        public GetAllProduct(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<ProductModel> Invoke()
        {
            var dbOferts = _productRepository.GetShopProducts();
            if (dbOferts == null)
            {
                return null;
            }
            var Oferts = AutoMapper.Mapper.Map<List<ProductModel>>(dbOferts);

            return Oferts;
        }
    }
}