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
using Task = Task_Management_System.Models.Task;

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
                            List<User> children = context.Users.Where(e=>e.Role=="child").ToList();
                            return View("../Child/Index", children);
                        }
                        else
                        {
                            List<Task> tasks = context.Tasks.Where(c => c.UserId == user.Id).ToList();
                            ChildDetailViewModel childDetailViewModel = new ChildDetailViewModel(user);
                            childDetailViewModel.Tasks = tasks;
                            return View("ChildDashboard", childDetailViewModel);
                        }
                    }
                }
                return View("Index", userView);
            }
            else
            {
                return View("Index", userView);
            }
        }


        public IActionResult SignUp()
        {
            return View("SignUp");
        }

        [HttpPost]
        public IActionResult SignUp(UserSignUpViewModel userSignUpViewModel)
        {
            if (ModelState.IsValid)
            {
                User child = new User
                {
                    FirstName = userSignUpViewModel.FirstName,
                    LastName = userSignUpViewModel.LastName,
                    Age = userSignUpViewModel.Age,
                    Gender = userSignUpViewModel.Gender,
                    UserName = userSignUpViewModel.UserName,
                    Password = userSignUpViewModel.Password,
                    Role = userSignUpViewModel.Role
                };
                context.Users.Add(child);
                context.SaveChanges();
                UserViewModel userView = new UserViewModel("User sign up is complete. Please login now!");
                return View("Index",userView);
            }
            return View("SignUp");
        }


    }
}
