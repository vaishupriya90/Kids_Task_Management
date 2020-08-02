using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Task_Management_System.Data;
using Task_Management_System.Models;
using Task_Management_System.ViewModel;

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

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Child> children = context.Children.ToList();
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
                Child child = new Child
                {
                    FirstName=addChildViewModel.FirstName,
                    LastName=addChildViewModel.LastName,
                    Age=addChildViewModel.Age,
                    Gender=addChildViewModel.Gender

                };
                context.Children.Add(child);
                context.SaveChanges();

                return Redirect("/Child");
            }
            return View("Add",addChildViewModel);
        }

        [HttpGet]
        public IActionResult Delete()
        {
            ViewBag.children = context.Children.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] childIds)
        {
            foreach(int childId in childIds)
            {
                Child theChild = context.Children.Find(childId);
                context.Children.Remove(theChild);
            }
            context.SaveChanges();
            return Redirect("/Child");
        }
    }
}
