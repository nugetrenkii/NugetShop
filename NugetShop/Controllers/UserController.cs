using NugetShop.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NugetShop.IServices;
using NugetShop.Models;
using NugetShop.Services;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using Microsoft.AspNetCore.Identity;

namespace NugetShop.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserServices UserServices;
        private readonly ICartDetailServices cartDetailServices;
        private readonly ICartServices cartServices;
        private readonly IUserRoleServices userRoleServices;
        private DataContext context;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
            UserServices = new UserServices();
            cartDetailServices = new CartDetailServices();
            cartServices = new CartServices();
            userRoleServices = new UserRoleServices();
            context = new DataContext();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("acc");
            return RedirectToAction("Login");
        }
        public IActionResult Login(string username, string password)
        {

            var products = SessionServices.GetObjFromSession(HttpContext.Session, "Cart");
            if (ModelState.IsValid)
            {
                var data = context.User.Include("UserRoles").FirstOrDefault(s => s.UserName.Equals(username) && s.Password.Equals(password));
                if (data != null)
                {
                    //add Session
                    HttpContext.Session.SetString("acc", data.UserName);
                    HttpContext.Session.SetString("role", data.UserRoles.RoleName);

                    var acc = HttpContext.Session.GetString("acc");
                    TempData["Message"] = "Chào mừng ngài " + acc;

                    var x = UserServices.GetUserByName(acc).ToList();
                    var carts = cartServices.GetCartById(x[0].UserID);
                    var lstCart = cartServices.GetAllCarts();
                    if (carts == null)
                    {
                        Cart cart = new Cart()
                        {
                            CartID = x[0].UserID,
                            Description = "",
                        };
                        cartServices.CreateCart(cart);
                    }
                    HttpContext.Session.Remove("Cart");
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

        public IActionResult ShowListUser()
        {
            var User = context.User.Include("UserRoles").ToList();
            List<User> Users = UserServices.GetAllUsers();
            return View(User);
        }

        public IActionResult Details(Guid id)
        {
            DataContext dataContext = new DataContext();
            var User = dataContext.User.Find(id);
            return View(User);
        }
        //public class ApplicationUser : IdentityUser
        //{
        //    public string UserName { get; set; }
        //}
        //public class ApplicationUserManager : UserManager<ApplicationUser>
        //{
        //    public ApplicationUserManager(IUserStore<ApplicationUser> store)
        //        : base(store)
        //    {
        //    }

        //    public async Task<bool> IsUserNameUsed(string userName)
        //    {
        //        var user = await FindByNameAsync(userName);
        //        return user != null;
        //    }
        //}
        public IActionResult Create()
        {
            ViewBag.UserRole = new SelectList(userRoleServices.GetAllUserRole(), "UserRoleID", "RoleName");
            return View();
        }
        [HttpPost]
        public IActionResult Create(User user)
        {
            if (UserServices.CreateUser(user))
            {
                Cart cart = new Cart()
                {
                    CartID = user.UserID,
                    Description = null
                };
                cartServices.CreateCart(cart);
                return RedirectToAction("ShowListUser");
            }
            else return BadRequest();
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            //Lấy User từ database dựa theo id truyền vào từ route
            ViewBag.UserRole = new SelectList(userRoleServices.GetAllUserRole(), "UserRoleID", "RoleName");
            User p = UserServices.GetUserById(id);
            return View(p);
        }

        public IActionResult Edit(User p)
        {
            ViewBag.UserRole = new SelectList(userRoleServices.GetAllUserRole(), "UserRoleID", "RoleName");
            if (UserServices.UpdateUser(p))
            {
                return RedirectToAction("ShowListUser");
            }
            else
            {
                return BadRequest();
            }
        }
        public IActionResult Delete(Guid id)
        {
            if (UserServices.DeleteUser(id))
            {
                return RedirectToAction("ShowListUser");
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
