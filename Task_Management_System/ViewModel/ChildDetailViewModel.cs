using System;
using System.Collections.Generic;
using Task_Management_System.Areas.Identity.Data;
using Task_Management_System.Models;
using Task = Task_Management_System.Models.Task;

namespace Task_Management_System.ViewModel
{
    public class ChildDetailViewModel
    {

        public string ChildId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Age { get; set; }

        public string Gender { get; set; }

        public List<Task> Tasks { get; set; }

        public ChildDetailViewModel()
        {
        }

        public ChildDetailViewModel(CustomIdentityUser customIdentityUser)
        {
            ChildId = customIdentityUser.Id;
            FirstName = customIdentityUser.FirstName;
            LastName = customIdentityUser.LastName;
            Age = customIdentityUser.Age;
            Gender = customIdentityUser.Gender;
        }
    }
}
