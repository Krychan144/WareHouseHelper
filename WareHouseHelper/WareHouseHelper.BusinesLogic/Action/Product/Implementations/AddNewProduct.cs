using System;
using System.Collections.Generic;
using System.Text;
using WareHouseHelper.BusinesLogic.Action.Product.Interfaces;
using WareHouseHelper.BusinesLogic.Models;
using WareHouseHelper.DataAccess.Repositories.Interfaces;

namespace WareHouseHelper.BusinesLogic.Action.Product.Implementations
{
    public class AddNewProduct : IAddNewProduct
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductTypeRepository _productTypeRepository;

        public AddNewProduct(IProductRepository productRepository,
            IProductTypeRepository productTypeRepository)
        {
            _productRepository = productRepository;
            _productTypeRepository = productTypeRepository;
        }

        public Guid Invoke(ProductModel product, Guid typeId)
        {
            if (!product.IsValid() || typeId == Guid.Empty)
            {
                return Guid.Empty;
            }

            var Type = _productTypeRepository.GetById(typeId);

            if (Type == null)
            {
                return Guid.Empty;
            }

            var newProduct = AutoMapper.Mapper.Map<DataAccess.Models.Product>(product);
            newProduct.ProductType = AutoMapper.Mapper.Map<DataAccess.Models.ProductType>(Type);

            _productRepository.Add(newProduct);
            _productRepository.Save();

            return newProduct.Id;
        }
    }
}