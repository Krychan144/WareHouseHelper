using System;
using System.Collections.Generic;
using System.Text;
using WareHouseHelper.BusinesLogic.Action.Product.Interfaces;
using WareHouseHelper.BusinesLogic.Models;
using WareHouseHelper.DataAccess.Repositories.Interfaces;

namespace WareHouseHelper.BusinesLogic.Action.Product.Implementations
{
    public class GetProductById : IGetProductById
    {
        private readonly IProductRepository _productRepository;

        public GetProductById(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ProductModel Invoke(Guid Id)
        {
            if (Id == Guid.Empty)
            {
                return null;
            }
            var dbProduct = _productRepository.GetById(Id);
            if (dbProduct == null)
            {
                return null;
            }
            var product = AutoMapper.Mapper.Map<ProductModel>(dbProduct);

            return product;
        }
    }
}