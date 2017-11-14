using System;
using System.Collections.Generic;
using System.Text;
using WareHouseHelper.BusinesLogic.Action.Base;

namespace WareHouseHelper.BusinesLogic.Action.Product.Interfaces
{
    public interface IDeleteProduct : IAction
    {
        bool Invoke(Guid productId);
    }
}