using System;

namespace WareHouseHelper.WEB.Models.Product
{
    public class ProductInWareHouseViewModel
    {
        public Guid ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal ProductExpense { get; set; }

        public int ProductQuantity { get; set; }

        public Guid ProductTypeId { get; set; }

        public string ProductTypeName { get; set; }

        public ProductNameToFindViewModel ProductToFind { get; set; }
    }
}