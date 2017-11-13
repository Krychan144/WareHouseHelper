using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WareHouseHelper.WEB.Controllers
{
    public class ProductController : Controller
    {
        // GET: /<controller>/
        public IActionResult AddProduct()
        {
            return View();
        }

        public IActionResult Management()
        {
            return View();
        }
    }
}