using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Task_Management_System.Data;
using Task_Management_System.Models;
using Task_Management_System.ViewModel;

namespace Task_Management_System.Controllers
{
    public class HomeController : Controller
    {
        private ManageDbContext context;

        public HomeController(ManageDbContext dbContext)
        {
            context = dbContext;

        }

        public IActionResult Index()
        {
            UserViewModel userViewModel = new UserViewModel();
            return View(userViewModel);
        }

        [HttpPost]
        public IActionResult SignIn(string userName, string password)
        {
            List<User> users = context.Users.Where(e => e.UserName == userName).ToList();
            UserViewModel userView = new UserViewModel("User Id/Password is incorrect!");
            if (users != null && users.Count > 0)
            {
                foreach (var user in users)
                {
                    if (user.Password.Equals(password))
                    {
                        if (user.Role == "parent")
                        {
                            List<Child> children = context.Children.ToList();
                            return View("../Child/Index", children);
                        }
                        else
                            return View();
                    }
                }
                return View("Index", userView);
            }
            else
            {
                return View("Index", userView);
            }
        }
    }
}
