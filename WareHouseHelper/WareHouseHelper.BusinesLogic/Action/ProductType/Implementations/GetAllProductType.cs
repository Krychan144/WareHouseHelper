using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WareHouseHelper.BusinesLogic.Action.ProductType.Interface;
using WareHouseHelper.BusinesLogic.Models;
using WareHouseHelper.DataAccess.Repositories.Interfaces;

namespace WareHouseHelper.BusinesLogic.Action.ProductType.Implementations
{
    public class GetAllProductType : IGetAllProductType
    {
        private readonly IProductTypeRepository _productTypeRepository;

        public GetAllProductType(IProductTypeRepository productTypeRepository)
        {
            _productTypeRepository = productTypeRepository;
        }

        public List<ProductTypeModel> Invoke()
        {
            var dbProductType = _productTypeRepository.GetAll();
            if (dbProductType.Count() == 0)
            {
                return null;
            }
            var productTypeList = AutoMapper.Mapper.Map<List<ProductTypeModel>>(dbProductType);
            return productTypeList;
        }
    }
}