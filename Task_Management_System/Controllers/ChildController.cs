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

        public IActionResult Detail(int id)
        {
            Child theChild = context.Children.Single(e => e.Id == id);

            ChildDetailViewModel childDetailViewModel = new ChildDetailViewModel(theChild);

            return View(childDetailViewModel);
        }

        //[HttpGet]
        //public IActionResult Delete()
        //{
        //    ViewBag.children = context.Children.ToList();
        //    return View();
        //}

        [HttpPost]
        //[Route("Child/Delete/{childId} ")]
        public IActionResult Delete(int childId)
        {
            //Console.WriteLine("Child Id to be deleted: "+childId);
            Child theChild = context.Children.Single(e=>e.Id == childId);
            context.Children.Remove(theChild);
            
            context.SaveChanges();
            return Redirect("/Child");
        }

        [HttpGet]
        [Route("Child/Edit/{childId}")]
        public IActionResult Edit(int childId)
        {
            Child theChild = context.Children.Single(e => e.Id == childId);
            return View(theChild);
        }

        [HttpPost]
        public IActionResult Edit(Child child)
        {
            Child c = context.Children.Find(child.Id);

            c.FirstName = child.FirstName;
            c.LastName = child.LastName;
            c.Age = child.Age;
            c.Gender = child.Gender;
            
            context.SaveChanges();
            return Redirect("/Child");
        }
    }
}
