using System;
using Task_Management_System.Models;

namespace Task_Management_System.ViewModel
{
    public class TaskDetailViewModel
    {
        public int TaskId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Point { get; set; }

        public Child Child { get; set; }

        public int ChildId { get; set; }

        public TaskDetailViewModel(Task theTask)
        {
            Name = theTask.Name;
            Description = theTask.Description;
            Point = theTask.Point;
            TaskId = theTask.Id;
            ChildId = theTask.ChildId;
        }
    }
}
