using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NugetShop.IServices;
using NugetShop.Models;
using NugetShop.Services;
using NugetShop.ViewModels;
using System.Diagnostics;

namespace NugetShop.Controllers
{
    public class CartController : Controller
    {
        private readonly ILogger<CartController> _logger;
        private readonly IProductServices productServices;
        private readonly ICartDetailServices cartDetailServices;
        private readonly IUserServices userServices;
        private readonly ICartServices cartServices;
        private readonly IBillDetailServices billDetailServices;
        private readonly IBillServices billServices;

        public CartController(ILogger<CartController> logger)
        {
            _logger = logger;
            productServices = new ProductServices();
            userServices = new UserServices();
            cartDetailServices = new CartDetailServices();
            cartServices = new CartServices();
            billServices= new BillServices();
            billDetailServices = new BillDetailServices();
        }
        public IActionResult AddToCart(CartView cartView)
        {
            
            var product = productServices.GetProductById(cartView.ProductID);
            var acc = HttpContext.Session.GetString("acc");
            //var id = userServices.GetAllUsers().FirstOrDefault(c => c.UserName == acc).UserID;
            var cart = cartServices.GetAllCarts().FirstOrDefault(x => x.User.UserName == acc);
            var cartDetail = cartDetailServices.GetAllCartDetails().FirstOrDefault(x => x.ProductID == cartView.ProductID && x.UserID == cart.CartID);
            if (cartDetail != null)
            {
                if (cartDetail.Quantity + cartView.Quantity <= product.Quantity)
                {
                    cartDetail.Quantity += 1;
                    cartDetailServices.UpdateCartDetail(cartDetail);
                }
                else
                {
                    cartDetail.Quantity = product.Quantity;
                    cartDetailServices.UpdateCartDetail(cartDetail);
                    TempData["bug"] = "Trong kho đã hết số lượng sản phẩm mà bạn yêu cầu ";
                    return RedirectToAction("Details", "Home", new { id = cartDetail.ProductID });
                }
            }
            else
            {
                var cartDetails = new CartDetail()
                {
                    CartDetailID = Guid.NewGuid(),
                    ProductID = product.ProductID,
                    UserID = cart.CartID,
                    Quantity = 1,
                    Status = 0,
                    Price = product.Price

                };
                cartDetailServices.CreateCartDetail(cartDetails);
            }
            return RedirectToAction("ShowListCart");
        }
       public IActionResult ShowListCart()
        {
            var acc = HttpContext.Session.GetString("acc");
            var user = userServices.GetUserByName(acc)[0].UserID;
            List<CartDetail> cartDetails = cartDetailServices.GetAllCartDetails().Where(c => c.UserID == user).ToList();
            //decimal tongtien = cartDetails.Sum(c => c.Quantity * c.Price);
            //var totalQuantity = cartDetails.Sum(c => c.Quantity * c.Price);
            ViewBag.TongTien = cartDetails.Sum(x => x.Quantity * x.Price);
            return View(cartDetails);
        }
        public IActionResult DeleteCart(Guid id)
        {
            var carts = SessionServices.GetObjFromSesssion(HttpContext.Session, "Cart"); // lấy dữ liệu 
            CartView productRemove = carts.FirstOrDefault(c => c.ProductID == id);
            if (productRemove != null)
            {
                carts.Remove(productRemove);
            }
            cartDetailServices.DeleteCartDetail(id);
            SessionServices.SetObjToSession(HttpContext.Session, "Cart", carts); // gán lại dữ liệu
            return RedirectToAction("ShowListCart", "Cart");
        }

        [HttpPost]
        public IActionResult UpdateCart(Guid idsp, int quantity)
        {
            var acc = HttpContext.Session.GetString("acc");
            var id = userServices.GetUserByName(acc)[0].UserID;
            var product = productServices.GetProductById(idsp);
            List<CartDetail> cartDetails = new(cartDetailServices.GetAllCartDetails().Where(c => c.UserID == id).ToList());
            var a = cartDetails.Find(x => x.ProductID == idsp && x.UserID == id);

            if (quantity <= product.Quantity)
            {
                a.Quantity = quantity;
                cartDetailServices.UpdateCartDetail(a);
            }
            else
            {
                TempData["quantityCart"] = "Số lượng bạn chọn đã đạt mức tối đa của sản phẩm này";
            }
            cartDetailServices.UpdateCartDetail(a);
            ViewBag.TongTien = cartDetails.Sum(x => x.Quantity * x.Price);
            return RedirectToAction("ShowListCart");
        }

        public IActionResult CheckOut()
        {
            var acc = HttpContext.Session.GetString("acc");
            var id = userServices.GetUserByName(acc)[0].UserID;
            List<CartDetail> cartDetails = new(cartDetailServices.GetAllCartDetails().Where(c => c.UserID == id).ToList());
            var newBill = new Bill()
            {
                BillID = Guid.NewGuid(),
                UserID = id,
                DateCreated = DateTime.Now,
                Status = 1,
                TotalAmount = cartDetails.Sum(item => item.Price * item.Quantity),
            };
            billServices.CreateBill(newBill);
            foreach (var item in cartDetails)
            {
                billDetailServices.CreateBillDetail(
                    new BillDetail
                {
                    BillDetailID = Guid.NewGuid(),
                    BillID = newBill.BillID,
                    ProductID = item.ProductID,
                    Price = item.Price,
                    Quantity = item.Quantity,
                });
                cartDetailServices.DeleteCartDetail(item.CartDetailID);
                var products = productServices.GetProductById(item.ProductID);
                products.Quantity -= item.Quantity;
                productServices.UpdateProduct(products);
            }
            return RedirectToAction("ShowListCart");

        }
        public IActionResult ViewBill()
        {
            var acc = HttpContext.Session.GetString("acc");
            var id = userServices.GetUserByName(acc)[0].UserID;
            List<Bill> bills = billServices.GetAllBills();
            return View(bills);
        } 
        public IActionResult ViewBillDetail()
        {
            var acc = HttpContext.Session.GetString("acc");
            var id = userServices.GetUserByName(acc)[0].UserID;
            List<BillDetail> billDetails = billDetailServices.GetAllBillDetails();
            return View(billDetails);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
