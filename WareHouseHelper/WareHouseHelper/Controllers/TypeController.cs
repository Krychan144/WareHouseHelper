using System;
using Microsoft.AspNetCore.Mvc;
using WareHouseHelper.BusinesLogic.Action.ProductType.Implementations;
using WareHouseHelper.BusinesLogic.Action.ProductType.Interface;
using WareHouseHelper.BusinesLogic.Models;
using WareHouseHelper.WEB.Models.ProductType;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WareHouseHelper.WEB.Controllers
{
    public class TypeController : Controller
    {
        private readonly IAddProductType _addProductType;

        public TypeController(IAddProductType addProductType)
        {
            _addProductType = addProductType;
        }

        [HttpGet("AddProductType")]
        public IActionResult AddProductType()
        {
            return View();
        }

        [HttpPost("AddProductType")]
        public IActionResult AddProductType(AddProductTypeViewModel model)
        {
            var productTypeToAddModel = new ProductTypeModel
            {
                Name = model.TypeName,
            };
            var addMealTypeAction = _addProductType.Invoke(productTypeToAddModel);

            if (addMealTypeAction == Guid.Empty)
            {
                return RedirectToAction("AddProductType", "Type");
            }
            return RedirectToAction("AddProductType", "Type");
        }
    }
}