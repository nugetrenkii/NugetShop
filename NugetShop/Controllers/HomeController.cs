using NugetShop.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NugetShop.IServices;
using NugetShop.Models;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Security.Cryptography;
using System.Text;

namespace NugetShop.Controllers
{
    public class HomeController : Controller
    {
        DataContext context;
        private readonly ILogger<HomeController> _logger;
        private readonly IProductServices productServices;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            productServices = new ProductServices();
            context = new DataContext();
        }

        public IActionResult Index()
        {
            var Product = context.Products.Take(8).Include("Colors").Include("Size").Include("Image").ToList();
            return View(Product);
        }

        public IActionResult Search(string searchString)
        {
            if (searchString != null)
            {
                var product1 = productServices.GetProductByName(searchString);
                TempData["search"] = "Danh sách tìm kiếm";
                ViewBag.Product1 = product1;
            }
            else
            {
                var Product1 = context.Products.Take(9).Include("Colors").Include("Size").Include("Image").ToList();
                TempData["search"] = "Sản phẩm mới";
                ViewBag.Product1 = Product1;
            }
            var Product2 = context.Products.Take(9).Include("Colors").Include("Size").Include("Image").OrderByDescending(c => c.Price).ToList();
            ViewBag.Product2 = Product2;
            return View();
        }

        public IActionResult GioiThieu()
        {
            return View();
        }   
        public IActionResult GioHang()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Admin()
        {
            string acc = HttpContext.Session.GetString("acc");
            if (acc != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string phone, string password)
        {

            if (ModelState.IsValid)
            {
                var data = context.User.Where(s => s.Phone.Equals(phone) && s.Password.Equals(password)).ToList();
                if (data.Count() > 0)
                {
                    //add Session
                    HttpContext.Session.SetString("acc", data.FirstOrDefault().Phone);
                    HttpContext.Session.SetString("role", data.FirstOrDefault().UserRoleID.ToString());
                    var acc = HttpContext.Session.GetString("acc");
                    TempData["Message"] = "Xin chào " + acc + " đã đến với MixiShop";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["AlertMessage"] = "Login failed";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }
        public IActionResult ChiTietSanPham()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Details(Guid id)
        {
            DataContext dataContext = new DataContext();
            var product = dataContext.Products.Find(id);
            return View(product);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}