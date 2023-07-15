using NugetShop.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NugetShop.IServices;
using NugetShop.Models;
using NugetShop.Services;
using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace NugetShop.Controllers
{
    public class ProductController : Controller
    {
        private DataContext context;
        private readonly ILogger<ProductController> _logger;
        private readonly IProductServices productServices;
        private readonly SessionServices sessionServices;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
            productServices = new ProductServices();
            context = new DataContext();
            sessionServices = new SessionServices();
        }
        public IActionResult Index()
        {
            var Product = context.Products.Take(8).Include("Colors").Include("Size").Include("Image").Where(p => p.Status < 3).ToList();
            return View(Product);
        }

        public IActionResult ShowListProduct()
        {
            var Product = context.Products.Include("Colors").Include("Size").Include("Image").ToList();
            return View(Product);
        }

        public IActionResult Details(Guid id)
        {
            var product = context.Products.Where(c => c.ProductID == id).Include(c => c.Image).FirstOrDefault();
            return View(product);          
        }
        public IActionResult Create()
        {
            ViewBag.Colors = new SelectList(context.Color.ToList(), "ColorID", "ColorName");
            ViewBag.Size = new SelectList(context.Size.ToList(), "SizeID", "SizeName");
            ViewBag.Image = new SelectList(context.Images.ToList(), "ImageID", "Path");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product p)
        {
            if (productServices.CreateProduct(p))
            {
                return RedirectToAction("ShowListProduct");
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            ViewBag.Color = new SelectList(context.Color.ToList(), "ColorID", "ColorName");
            ViewBag.Size = new SelectList(context.Size.ToList(), "SizeID", "SizeName");
            ViewBag.Image = new SelectList(context.Images.ToList(), "ImageID", "Path");
            Product product = productServices.GetProductById(id);
            return View(product);
        }

        public IActionResult Edit(Product p)
        {
           
            if (productServices.UpdateProduct(p))
            {
                return RedirectToAction("ShowListProduct");
            }
            else
            {
                return BadRequest();
            }
        }
        public IActionResult Delete(Guid id)
        {
            if (productServices.DeleteProduct(id))
            {
                return RedirectToAction("ShowListProduct");
            }
            else
            {
                return BadRequest();
            }
        }

        public IActionResult SanPham()
        {
            var Product = context.Products.Take(9).Include("Colors").Include("Size").Include("Image").Where(Product => Product.Status < 3).ToList();
            return View(Product);
        }
        public IActionResult AddToCart(Guid id)
        {

            var product = productServices.GetProductById(id);

            var products = SessionServices.GetObjFromSession(HttpContext.Session, "Cart");
            if (products.Count == 0)
            {
                products.Add(product);
                SessionServices.SetObjToSession(HttpContext.Session, "Cart", products);
            }
            else
            {
                if (SessionServices.CheckObjInList(id, products))
                {
                    return Content("List đã chứa sản phẩm này");
                }
                else
                {
                    products.Add(product);
                    SessionServices.SetObjToSession(HttpContext.Session, "Cart", products);
                }
            }
            return RedirectToAction("ShowCart");
        }
       

       
        public IActionResult ShowCart()
        {
            var products = SessionServices.GetObjFromSesssion(HttpContext.Session, "Cart");
            return View(products);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
