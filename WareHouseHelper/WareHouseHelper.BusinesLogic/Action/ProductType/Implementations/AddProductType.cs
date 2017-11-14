using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WareHouseHelper.BusinesLogic.Action.ProductType.Interface;
using WareHouseHelper.BusinesLogic.Models;
using WareHouseHelper.DataAccess.Repositories.Interfaces;

namespace WareHouseHelper.BusinesLogic.Action.ProductType.Implementations
{
    public class AddProductType : IAddProductType
    {
        private readonly IProductTypeRepository _productTypeRepository;

        public AddProductType(IProductTypeRepository productTypeRepository)
        {
            _productTypeRepository = productTypeRepository;
        }

        public Guid Invoke(ProductTypeModel productType)
        {
            if (!productType.IsValid())
            {
                return Guid.Empty;
            }

            var newProductType = AutoMapper.Mapper.Map<DataAccess.Models.ProductType>(productType);
            var ifexist = _productTypeRepository.FindBy(c => c.Name == newProductType.Name);
            if (ifexist.Count() == 0)
            {
                _productTypeRepository.Add(newProductType);
                _productTypeRepository.Save();

                return newProductType.Id;
            }
            return ifexist.SingleOrDefault().Id;
        }
    }
}