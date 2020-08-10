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
            return View();
        }

        
    }
}
