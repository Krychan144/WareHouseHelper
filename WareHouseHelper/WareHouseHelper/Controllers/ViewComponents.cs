using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WareHouseHelper.WEB.Models.Common;

namespace WareHouseHelper.WEB.Controllers
{
    public class DeleteModalViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(DeleteModalViewModel model)
        {
            return View(model);
        }
    }
}