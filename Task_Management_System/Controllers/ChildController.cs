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

        [Authorize(Roles = "parent")]
        public async System.Threading.Tasks.Task<IActionResult> IndexAsync()
        {
            IList<CustomIdentityUser> customIdentityUsers = await userManager.GetUsersInRoleAsync("child");
            return View(customIdentityUsers);
        }

        [Authorize(Roles = "parent")]
        [HttpGet]
        public IActionResult Add()
        {
            AddChildViewModel addChildViewModel = new AddChildViewModel();
            return View(addChildViewModel);
        }

        [Authorize(Roles = "parent")]
        [HttpPost]
        public IActionResult Add(AddChildViewModel addChildViewModel)
        {
            if (ModelState.IsValid)
            {
                CustomIdentityUser child = new CustomIdentityUser
                {
                    FirstName = addChildViewModel.FirstName,
                    LastName = addChildViewModel.LastName,
                    Age = addChildViewModel.Age,
                    Gender = addChildViewModel.Gender,
                    //UserName=addChildViewModel.FirstName,
                    //Role="child"
                };
                context.customIdentityUsers.Add(child);
                context.SaveChanges();
                return Redirect("/Child");
            }
            return View("Add", addChildViewModel);
        }

        [Authorize(Roles = "parent")]
        public async System.Threading.Tasks.Task<IActionResult> DetailAsync(string id)
        {
            CustomIdentityUser customIdentityUser = await userManager.FindByIdAsync(id);

            ChildDetailViewModel childDetailViewModel = new ChildDetailViewModel(customIdentityUser);

            List<Task> tasks = context.Tasks.Where(c => c.UserId == customIdentityUser.Id).ToList();

            childDetailViewModel.Tasks = tasks;

            return View(childDetailViewModel);
        }

        [Authorize(Roles = "parent")]
        [HttpPost]
        public async System.Threading.Tasks.Task<IActionResult> DeleteAsync(string childId)
        {
            List<Task> tasks = context.Tasks.Where(e => e.UserId == childId).ToList();
            foreach (Task t in tasks)
            {
                context.Tasks.Remove(t);
            }
            CustomIdentityUser customIdentityUser = await userManager.FindByIdAsync(childId);
            await userManager.DeleteAsync(customIdentityUser);
            context.SaveChanges();
            return Redirect("/Child");
        }

        [Authorize(Roles = "parent")]
        [HttpGet]
        public IActionResult Edit(string childId)
        {
            CustomIdentityUser customIdentityUser = context.customIdentityUsers.Single(e => e.Id == childId);
            return View(customIdentityUser);
        }

        [Authorize(Roles = "parent")]
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

        [Authorize(Roles = "child")]
        public async System.Threading.Tasks.Task<IActionResult> ChildDashboardAsync(string id)
        {
            CustomIdentityUser customIdentityUser = await userManager.FindByIdAsync(id);

            ChildDetailViewModel childDetailViewModel = new ChildDetailViewModel(customIdentityUser);

            List<Task> tasks = context.Tasks.Where(c => c.UserId == customIdentityUser.Id).ToList();

            childDetailViewModel.Tasks = tasks;

            return View(childDetailViewModel);
        }

    }
}
