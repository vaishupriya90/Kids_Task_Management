using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Task_Management_System.Areas.Identity.Data;

namespace Task_Management_System.Models
{
    public class Task
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Point { get; set; }

        public CustomIdentityUser User { get; set; }

        public string UserId { get; set; }

        public Task()
        {
        }

        public Task(string name,string description,int point)
        {
            Name = name;
            Description = description;
            Point = point;

        }
        
    }
}
