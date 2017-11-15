using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WareHouseHelper.BusinesLogic.Action.Product.Interfaces;
using WareHouseHelper.BusinesLogic.Action.ProductType.Interface;
using WareHouseHelper.BusinesLogic.Models;
using WareHouseHelper.WEB.Models.Common;
using WareHouseHelper.WEB.Models.Product;

namespace WareHouseHelper.WEB.Controllers
{
    public class ProductController : Controller
    {
        private readonly IGetAllProducts _getAllProducts;
        private readonly IGetAllProductType _getAllProductType;
        private readonly IAddNewProduct _addNewProduct;
        private readonly IDeleteProduct _deleteProduct;
        private readonly IGetProductById _getProductById;
        private readonly IEditProduct _editProduct;

        public ProductController(IGetAllProducts getAllProducts,
            IGetAllProductType getAllProductType,
            IAddNewProduct addNewProduct, IDeleteProduct deleteProduct,
            IGetProductById getProductById,
            IEditProduct editProduct)
        {
            _getAllProducts = getAllProducts;
            _getAllProductType = getAllProductType;
            _addNewProduct = addNewProduct;
            _deleteProduct = deleteProduct;
            _getProductById = getProductById;
            _editProduct = editProduct;
        }

        [HttpGet("AddProduct")]
        public IActionResult AddProduct()
        {
            var productType = _getAllProductType.Invoke();
            var model = new ProductToAddViewModel { ProductTypes = new List<SelectListItem>() };

            foreach (var item in productType)
            {
                model.ProductTypes.Add(new SelectListItem { Text = item.Name, Value = item.Id.ToString() });
            }
            return View(model);
        }

        [HttpPost("AddProduct")]
        public IActionResult AddProduct(ProductToAddViewModel model)
        {
            var productModel = new ProductModel
            {
                Name = model.ProductName,
                Expense = model.ProductExpense,
                Quantity = model.ProductQuantity
            };

            var addNewMealAction = _addNewProduct.Invoke(productModel, model.ProductTypeId);
            if (addNewMealAction == Guid.Empty)
            {
                return RedirectToAction("AddProduct", "Product");
            }
            return RedirectToAction("Management", "Product");
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

        [HttpPost("Delete")]
        public IActionResult Delete(DeleteItemViewModel model)
        {
            var deleteProductAction = _deleteProduct.Invoke(model.id);
            if (deleteProductAction == false)
            {
                return RedirectToAction("Management", "Product");
            }
            return RedirectToAction("Management", "Product");
        }

        [HttpGet("EditProduct/{ProductId}")]
        public IActionResult EditProduct(Guid productId)
        {
            var productType = _getAllProductType.Invoke();
            var model = new ProductToEditViewModel { ProductTypes = new List<SelectListItem>() };

            foreach (var item in productType)
            {
                model.ProductTypes.Add(new SelectListItem { Text = item.Name, Value = item.Id.ToString() });
            }

            var product = _getProductById.Invoke(productId);
            model.ProductId = productId;
            model.ProductExpense = product.Expense;
            model.ProductName = product.Name;
            model.ProductQuantity = product.Quantity;

            return View(model);
        }

        [HttpPost("EditProduct/{ProductId}")]
        public IActionResult EditProduct(Guid productId, ProductToEditViewModel model)
        {
            var productToEdit = new ProductModel
            {
                Id = model.ProductId,
                Name = model.ProductName,
                Expense = model.ProductExpense,
                Quantity = model.ProductQuantity,
                ProductType = new ProductTypeModel
                {
                    Id = model.ProductTypeId
                }
            };
            var editProductAction = _editProduct.Invoke(productToEdit);
            if (editProductAction == false)
            {
                return RedirectToAction("EditProduct", "Product", new { ProductId = productId });
            }
            return RedirectToAction("Management", "Product");
        }

        [HttpGet("FindProduct")]
        public IActionResult FindProduct()
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

        [HttpPost("FindProduct")]
        public IActionResult FindProduct(ProductInWareHouseViewModel NameModel)
        {
            var name = NameModel.ProductToFind.ProductName;
            var productInWareHouse = _getAllProducts.Invoke();

            if (!string.IsNullOrEmpty(name))
            {
                var model = new List<ProductInWareHouseViewModel>();
                foreach (var item in productInWareHouse)
                {
                    if (item.Name.ToLower().Contains(name))
                    {
                        model.Add(new ProductInWareHouseViewModel
                        {
                            ProductName = item.Name,
                            ProductExpense = item.Expense,
                            ProductQuantity = item.Quantity,
                            ProductTypeName = item.ProductType.Name
                        });
                    }
                }

                return View(model);
            }
            else
            {
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
        }
    }
}