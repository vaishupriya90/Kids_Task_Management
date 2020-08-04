using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Task_Management_System.Models;

namespace Task_Management_System.ViewModel
{
    public class TaskDetailViewModel
    {
        public int TaskId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Point { get; set; }

        //public Child Child { get; set; }

        //public int ChildId { get; set; }

        public string ChildName { get; set; }



        public TaskDetailViewModel(Task theTask)
        {
            TaskId = theTask.Id;
            Name = theTask.Name;
            Description = theTask.Description;
            Point = theTask.Point;
            ChildName = theTask.Child.FirstName + theTask.Child.LastName;
        }

       
    }
}