using Microsoft.AspNetCore.Mvc;
using NugetShop.IServices;
using NugetShop.Models;
using NugetShop.Services;
using System.Diagnostics;

namespace NugetShop.Controllers
{
    public class ColorController : Controller
    {
        private readonly ILogger<ColorController> _logger;
        private readonly IColorServices ColorServices;

        public ColorController(ILogger<ColorController> logger)
        {
            _logger = logger;
            ColorServices = new ColorServices();
        }

        public IActionResult ShowListColor()
        {
            List<Color> Colors = ColorServices.GetAllColors();
            return View(Colors);
        }

        public IActionResult Details(Guid id)
        {
            DataContext dataContext = new DataContext();
            var Color = dataContext.Color.Find(id);
            return View(Color);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Color p)
        {
            if (ColorServices.CreateColor(p))
            {
                return RedirectToAction("ShowListColor");
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            //Lấy Color từ database dựa theo id truyền vào từ route
            Color p = ColorServices.GetColorById(id);
            return View(p);
        }

        public IActionResult Edit(Color p)
        {
            if (ColorServices.UpdateColor(p))
            {
                return RedirectToAction("ShowListColor");
            }
            else
            {
                return BadRequest();
            }
        }
        public IActionResult Delete(Guid id)
        {
            if (ColorServices.DeleteColor(id))
            {
                return RedirectToAction("ShowListColor");
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
