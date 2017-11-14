using System;
using System.Collections.Generic;
using System.Text;
using WareHouseHelper.BusinesLogic.Action.Base;
using WareHouseHelper.BusinesLogic.Models;

namespace WareHouseHelper.BusinesLogic.Action.ProductType.Interface
{
    public interface IAddProductType : IAction
    {
        Guid Invoke(ProductTypeModel producType);
    }
}