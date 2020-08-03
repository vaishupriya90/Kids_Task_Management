using System;
using System.Collections.Generic;
using Task_Management_System.Models;
using Task = Task_Management_System.Models.Task;

namespace Task_Management_System.ViewModel
{
    public class ChildDetailViewModel
    {

        public int ChildId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        public List<Task> Tasks { get; set; }

        public ChildDetailViewModel()
        {
        }

        public ChildDetailViewModel(Child theChild)
        {
            ChildId = theChild.Id;
            FirstName = theChild.FirstName;
            LastName = theChild.LastName;
            Age = theChild.Age;
            Gender = theChild.Gender;
        }
    }
}
