using System;
using System.Collections.Generic;
using System.Text;
using WareHouseHelper.BusinesLogic.Action.Product.Interfaces;
using WareHouseHelper.DataAccess.Repositories.Interfaces;

namespace WareHouseHelper.BusinesLogic.Action.Product.Implementations
{
    public class DeleteProduct : IDeleteProduct
    {
        private readonly IProductRepository _productRepository;

        public DeleteProduct(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public bool Invoke(Guid productId)
        {
            if (productId == Guid.Empty)
            {
                return false;
            }
            var productToDelete = _productRepository.GetById(productId);
            if (productToDelete == null)
            {
                return false;
            }
            _productRepository.Delete(productToDelete);
            _productRepository.Save();
            return true;
        }
    }
}