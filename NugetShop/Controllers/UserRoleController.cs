using Microsoft.AspNetCore.Mvc;
using NugetShop.IServices;
using NugetShop.Models;
using NugetShop.Services;
using System.Diagnostics;

namespace NugetShop.Controllers
{
        public class UserRoleController : Controller
        {
            private readonly ILogger<UserRoleController> _logger;
            private readonly IUserRoleServices UserRoleServices;

            public UserRoleController(ILogger<UserRoleController> logger)
            {
                _logger = logger;
                UserRoleServices = new UserRoleServices();
            }

            public IActionResult ShowListUserRole()
            {
                List<UserRole> UserRoles = UserRoleServices.GetAllUserRole();
                return View(UserRoles);
            }

            public IActionResult Details(Guid id)
            {
                DataContext dataContext = new DataContext();
                var UserRole = dataContext.UserRole.Find(id);
                return View(UserRole);
            }
            public IActionResult Create()
            {
                return View();
            }
            [HttpPost]
            public IActionResult Create(UserRole p)
            {
                if (UserRoleServices.CreateUserRole(p))
                {
                    return RedirectToAction("ShowListUserRole");
                }
                else
                {
                    return BadRequest();
                }
            }
            [HttpGet]
            public IActionResult Edit(Guid id)
            {
                //Lấy UserRole từ database dựa theo id truyền vào từ route
                UserRole p = UserRoleServices.GetUserRoleById(id);
                return View(p);
            }

            public IActionResult Edit(UserRole p)
            {
                if (UserRoleServices.UpdateUserRole(p))
                {
                    return RedirectToAction("ShowListUserRole");
                }
                else
                {
                    return BadRequest();
                }
            }
            public IActionResult Delete(Guid id)
            {
                if (UserRoleServices.DeleteUserRole(id))
                {
                    return RedirectToAction("ShowListUserRole");
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
