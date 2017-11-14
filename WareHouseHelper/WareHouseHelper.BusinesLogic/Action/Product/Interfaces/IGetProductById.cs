﻿using System;
using System.Collections.Generic;
using System.Text;
using WareHouseHelper.BusinesLogic.Action.Base;
using WareHouseHelper.BusinesLogic.Models;

namespace WareHouseHelper.BusinesLogic.Action.Product.Interfaces
{
    public interface IGetProductById : IAction
    {
        ProductModel Invoke(Guid id);
    }
}