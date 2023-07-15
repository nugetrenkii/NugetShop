using Microsoft.AspNetCore.Mvc;

namespace NugetShop.Controllers
{
    public class BillController : Controller
    {
        
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Bill()
        {
            return View();
        }
    }
}
