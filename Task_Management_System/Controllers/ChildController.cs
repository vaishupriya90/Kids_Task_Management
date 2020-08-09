using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Task_Management_System.Areas.Identity.Data;
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
        private UserManager<CustomIdentityUser> userManager;

        public ChildController(ManageDbContext dbContext, UserManager<CustomIdentityUser> userManager)
        {
            context = dbContext;
            this.userManager = userManager;
        }

        public async System.Threading.Tasks.Task<IActionResult> IndexAsync()
        {
            IList<CustomIdentityUser> customIdentityUsers = await userManager.GetUsersInRoleAsync("child");
            return View(customIdentityUsers);
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
                CustomIdentityUser child = new CustomIdentityUser
                {
                    FirstName=addChildViewModel.FirstName,
                    LastName=addChildViewModel.LastName,
                    Age=addChildViewModel.Age,
                    Gender=addChildViewModel.Gender,
                    //UserName=addChildViewModel.FirstName,
                    //Role="child"
                };
                context.customIdentityUsers.Add(child);
                context.SaveChanges();
                return Redirect("/Child");
            }
            return View("Add",addChildViewModel);
        }

        public IActionResult Detail(CustomIdentityUser customIdentityUser)
        {

            ChildDetailViewModel childDetailViewModel = new ChildDetailViewModel(customIdentityUser);

            List<Task> tasks = context.Tasks.Where(c => c.UserId == customIdentityUser.Id).ToList();

            childDetailViewModel.Tasks=tasks;

            return View(childDetailViewModel);
        }

        [HttpPost]
        public IActionResult Delete(string childId)
        {
            CustomIdentityUser customIdentityUser=context.customIdentityUsers.Single(e => e.Id == childId);
            //User theChild = context.Users.Single(e=>e.Id == childId);
            context.Users.Remove(customIdentityUser);
            context.SaveChanges();
            return Redirect("/Child");
        }

        [HttpGet]
        public IActionResult Edit(string childId)
        {
            CustomIdentityUser customIdentityUser = context.customIdentityUsers.Single(e => e.Id == childId);
            return View(customIdentityUser);
        }

        [HttpPost]
        public IActionResult Edit(CustomIdentityUser child)
        {
            CustomIdentityUser c = context.customIdentityUsers.Find(child.Id);

            c.FirstName = child.FirstName;
            c.LastName = child.LastName;
            c.Age = child.Age;
            c.Gender = child.Gender;
            context.SaveChanges();
            return Redirect("/Child");
        }

        [Authorize(Roles ="child")]
        public IActionResult ChildDashboard(CustomIdentityUser customIdentityUser)
        {
            Console.WriteLine("Selected child Id is: " + customIdentityUser.Id);

            ChildDetailViewModel childDetailViewModel = new ChildDetailViewModel(customIdentityUser);

            List<Task> tasks = context.Tasks.Where(c => c.UserId == customIdentityUser.Id).ToList();

            childDetailViewModel.Tasks = tasks;

            return View(childDetailViewModel);
        }

    }
}
