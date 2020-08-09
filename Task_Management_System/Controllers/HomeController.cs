using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
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
            //UserViewModel userViewModel = new UserViewModel();

            return View();
        }

        

        //public IActionResult SignUp()
        //{
        //    return View("SignUp");
        //}

        //[HttpPost]
        //public IActionResult SignUp(UserSignUpViewModel userSignUpViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        User child = new User
        //        {
        //            FirstName = userSignUpViewModel.FirstName,
        //            LastName = userSignUpViewModel.LastName,
        //            Age = userSignUpViewModel.Age,
        //            Gender = userSignUpViewModel.Gender,
        //            UserName = userSignUpViewModel.UserName,
        //            Password = userSignUpViewModel.Password,
        //            Role = userSignUpViewModel.Role
        //        };
        //        context.Users.Add(child);
        //        context.SaveChanges();
        //        UserViewModel userView = new UserViewModel("User sign up is complete. Please login now!");
        //        return View("Index",userView);
        //    }
        //    return View("SignUp");
        //}


    }
}
