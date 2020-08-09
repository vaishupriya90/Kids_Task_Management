using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Task_Management_System.Data;
using Task_Management_System.Models;
using Task_Management_System.ViewModel;
using Task = Task_Management_System.Models.Task;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Task_Management_System.Controllers
{

    public class ChildController : Controller
    {
        private ManageDbContext context;


        public ChildController(ManageDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<User> children = context.Users.ToList();
            return View(children);
        }

        [HttpGet]
        public IActionResult Add()
        {
            AddChildViewModel addChildViewModel = new AddChildViewModel();
            return View(addChildViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddChildViewModel addChildViewModel)
        {
            if (ModelState.IsValid)
            {
                User child = new User
                {
                    FirstName=addChildViewModel.FirstName,
                    LastName=addChildViewModel.LastName,
                    Age=addChildViewModel.Age,
                    Gender=addChildViewModel.Gender,
                    //UserName=addChildViewModel.FirstName,
                    //Role="child"
                };
                context.Users.Add(child);
                context.SaveChanges();
                return Redirect("/Child");
            }
            return View("Add",addChildViewModel);
        }

        public IActionResult Detail(int id)
        {
            User theChild = context.Users.Single(e => e.Id == id);

            ChildDetailViewModel childDetailViewModel = new ChildDetailViewModel(theChild);

            List<Task> tasks = context.Tasks.Where(c => c.UserId == theChild.Id).ToList();

            childDetailViewModel.Tasks=tasks;

            return View(childDetailViewModel);
        }

        [HttpPost]
        public IActionResult Delete(int childId)
        {
            User theChild = context.Users.Single(e=>e.Id == childId);
            context.Users.Remove(theChild);
            context.SaveChanges();
            return Redirect("/Child");
        }

        [HttpGet]
        public IActionResult Edit(int childId)
        {
            User theChild = context.Users.Single(e => e.Id == childId);
            return View(theChild);
        }

        [HttpPost]
        public IActionResult Edit(User child)
        {
            User c = context.Users.Find(child.Id);

            c.FirstName = child.FirstName;
            c.LastName = child.LastName;
            c.Age = child.Age;
            c.Gender = child.Gender;
            context.SaveChanges();
            return Redirect("/Child");
        }

        [AllowAnonymous]
        public IActionResult ChildDashboard(int id)
        {
            User theChild = context.Users.Single(e => e.Id == id);

            ChildDetailViewModel childDetailViewModel = new ChildDetailViewModel(theChild);

            List<Task> tasks = context.Tasks.Where(c => c.UserId == theChild.Id).ToList();

            childDetailViewModel.Tasks = tasks;

            return View(childDetailViewModel);
        }

    }
}
