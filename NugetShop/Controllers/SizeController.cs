using Microsoft.AspNetCore.Mvc;
using NugetShop.IServices;
using NugetShop.Models;
using NugetShop.Services;
using System.Diagnostics;

namespace NugetShop.Controllers
{
    public class SizeController : Controller
    {
        private readonly ILogger<SizeController> _logger;
        private readonly ISizeServices SizeServices;

        public SizeController(ILogger<SizeController> logger)
        {
            _logger = logger;
            SizeServices = new SizeServices();
        }

        public IActionResult ShowListSize()
        {
            List<Size> Sizes = SizeServices.GetAllSizes();
            return View(Sizes);
        }

        public IActionResult Details(Guid id)
        {
            DataContext dataContext = new DataContext();
            var Size = dataContext.Size.Find(id);
            return View(Size);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Size p)
        {
            if (SizeServices.CreateSize(p))
            {
                return RedirectToAction("ShowListSize");
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            //Lấy Size từ database dựa theo id truyền vào từ route
            Size p = SizeServices.GetSizeById(id);
            return View(p);
        }

        public IActionResult Edit(Size p)
        {
            if (SizeServices.UpdateSize(p))
            {
                return RedirectToAction("ShowListSize");
            }
            else
            {
                return BadRequest();
            }
        }
        public IActionResult Delete(Guid id)
        {
            if (SizeServices.DeleteSize(id))
            {
                return RedirectToAction("ShowListSize");
            }
            else
            {
                return BadRequest();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
