using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WareHouseHelper.BusinesLogic.Action.Product.Interfaces;
using WareHouseHelper.BusinesLogic.Action.ProductType.Interface;
using WareHouseHelper.WEB.Models.Product;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WareHouseHelper.WEB.Controllers
{
    public class ProductController : Controller
    {
        private readonly IGetAllProducts _getAllProducts;
        private readonly IGetAllProductType _getAllProductType;

        public ProductController(IGetAllProducts getAllProducts, IGetAllProductType getAllProductType)
        {
            _getAllProducts = getAllProducts;
            _getAllProductType = getAllProductType;
        }

        [HttpGet("AddProduct")]
        public IActionResult AddProduct()
        {
            var productType = _getAllProductType.Invoke();
            var model = new ProductToAddViewModel() { ProductTypes = new List<SelectListItem>() };

            foreach (var item in productType)
            {
                model.ProductTypes.Add(new SelectListItem { Text = item.Name, Value = item.Id.ToString() });
            }
            return View(model);
        }

        [HttpGet("Management")]
        public IActionResult Management()
        {
            var productInWareHouse = _getAllProducts.Invoke();
            var model = productInWareHouse.Select(item => new ProductInWareHouseViewModel
            {
                ProductId = item.Id,
                ProductTypeName = item.ProductType.Name,
                ProductExpense = item.Expense,
                ProductQuantity = item.Quantity,
                ProductTypeId = item.ProductType.Id,
                ProductName = item.Name
            }).ToList();
            return View(model);
        }

        public IActionResult EditProduct()
        {
            return View();
        }
    }
}