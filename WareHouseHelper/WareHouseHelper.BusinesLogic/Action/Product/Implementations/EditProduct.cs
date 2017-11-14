using System;
using System.Collections.Generic;
using System.Text;
using WareHouseHelper.BusinesLogic.Action.Product.Interfaces;
using WareHouseHelper.BusinesLogic.Models;
using WareHouseHelper.DataAccess.Repositories.Interfaces;

namespace WareHouseHelper.BusinesLogic.Action.Product.Implementations
{
    public class EditProduct : IEditProduct
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductTypeRepository _productTypeRepository;

        public EditProduct(IProductRepository productRepository,
            IProductTypeRepository productTypeRepository)
        {
            _productRepository = productRepository;
            _productTypeRepository = productTypeRepository;
        }

        public bool Invoke(ProductModel model)
        {
            if (model == null)
            {
                return false;
            }

            var dbProductType = _productTypeRepository.GetById(model.ProductType.Id);
            if (dbProductType == null)
            {
                return false;
            }
            var productToEdit = _productRepository.GetById(model.Id);

            if (productToEdit == null)
            {
                return false;
            }

            productToEdit.Name = model.Name;
            productToEdit.Expense = model.Expense;
            productToEdit.ProductType = dbProductType;
            productToEdit.Quantity = model.Quantity;
            _productRepository.Edit(productToEdit);
            _productRepository.Save();
            return true;
        }
    }
}