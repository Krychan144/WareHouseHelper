using System;
using System.Collections.Generic;
using System.Text;

namespace WareHouseHelper.BusinesLogic.Models
{
    public class ProductModel : BaseModel
    {
        public string Name { get; set; }

        public decimal Expense { get; set; }

        public ProductTypeModel ProductType { get; set; }
        public int Quantity { get; set; }
    }
}