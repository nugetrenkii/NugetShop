using Microsoft.AspNetCore.Mvc;
using NugetShop.IServices;
using NugetShop.Models;
using NugetShop.Services;
using System.Diagnostics;

namespace NugetShop.Controllers
{
    public class ImageController : Controller
    {
        private readonly ILogger<ImageController> _logger;
        private readonly IImageServices ImageServices;

        public ImageController(ILogger<ImageController> logger)
        {
            _logger = logger;
            ImageServices = new ImageServices();
        }  

        public IActionResult ShowListImage()
        {
            List<Image> Images = ImageServices.GetAllImages();
            return View(Images);
        }

        public IActionResult Details(Guid id)
        {
            DataContext dataContext = new DataContext();
            var Image = dataContext.Images.Find(id);
            return View(Image);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Image p)
        {
            if (ImageServices.CreateImage(p))
            {
                return RedirectToAction("ShowListImage");
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            //Lấy Image từ database dựa theo id truyền vào từ route
            Image p = ImageServices.GetImageById(id);
            return View(p);
        }

        public IActionResult Edit(Image p)
        {
            if (ImageServices.UpdateImage(p))
            {
                return RedirectToAction("ShowListImage");
            }
            else
            {
                return BadRequest();
            }
        }
        public IActionResult Delete(Guid id)
        {
            if (ImageServices.DeleteImage(id))
            {
                return RedirectToAction("ShowListImage");
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
