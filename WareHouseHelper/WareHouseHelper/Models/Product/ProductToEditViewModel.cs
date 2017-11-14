using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WareHouseHelper.WEB.Models.Product
{
    public class ProductToEditViewModel
    {
        public Guid ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal ProductExpense { get; set; }

        public int ProductQuantity { get; set; }

        public Guid ProductTypeId { get; set; }

        public List<SelectListItem> ProductTypes { get; set; }
    }
}