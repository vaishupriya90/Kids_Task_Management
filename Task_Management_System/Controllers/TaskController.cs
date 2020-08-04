using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task_Management_System.Data;
using Task_Management_System.Models;
using Task_Management_System.ViewModel;
using Task = Task_Management_System.Models.Task;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Task_Management_System.Controllers
{
    public class TaskController : Controller
    {

        private ManageDbContext context;

        public TaskController(ManageDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Task> tasks = context.Tasks
                .Include(e=> e.Child).ToList();

            return View(tasks);
        }

        [HttpGet]
        public IActionResult Add()
        {
            List<Child> children = context.Children.ToList();
            AddTaskViewModel addTaskViewModel = new AddTaskViewModel(children);

            return View(addTaskViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddTaskViewModel addTaskViewModel)
        {
            if (ModelState.IsValid)
            {
                Child child = context.Children.Find(addTaskViewModel.ChildId);

                Task newTask = new Task
                {
                    Name = addTaskViewModel.TaskName,
                    Description = addTaskViewModel.Description,
                    Point = addTaskViewModel.Point,
                    Child = child
                };

                context.Tasks.Add(newTask);
                context.SaveChanges();

                return Redirect("/Task");
            }
            return View("Add", addTaskViewModel);
        }

        [HttpGet]
        public IActionResult Edit(int taskId)
        {
            Task theTask = context.Tasks.Single(e => e.Id == taskId);
            return View(theTask);
        }

        [HttpPost]
        public IActionResult Edit(Task task)
        {
            Task theTask = context.Tasks.Find(task.Id);

            theTask.Name = task.Name;
            theTask.Description = task.Description;
            theTask.Point = task.Point;

            context.SaveChanges();
            return Redirect("/Task");
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            Task theTask = context.Tasks.Include(e => e.Child)
               .Single(e => e.Id == id);
            TaskDetailViewModel taskDetailViewModel = new TaskDetailViewModel(theTask);

            return View(taskDetailViewModel);
        }

        [HttpPost]
        public IActionResult Delete(int taskId)
        {
            Task theTask = context.Tasks.Single(e => e.Id == taskId);
            context.Tasks.Remove(theTask);

            context.SaveChanges();
            return Redirect("/Task");
        }
    }
}
