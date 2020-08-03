using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Task_Management_System.Models;

namespace Task_Management_System.ViewModel
{
    public class AddTaskViewModel
    {

        [Required(ErrorMessage = "Task Name is required")]
        public string TaskName { get; set; }

        public string Description { get; set; }

        [Required]
        public int Point { get; set; }

        [Required(ErrorMessage ="Please Select a child to assign the tasks")]
        public int ChildId { get; set; }
        public List<SelectListItem> Children { get; set; }

        public AddTaskViewModel()
        {

        }

        public AddTaskViewModel(List<Child> children)
        {
            Children = new List<SelectListItem>();

            foreach(var child in children)
            {
                Children.Add(new SelectListItem
                {
                    Value = child.Id.ToString(),
                    Text = child.FirstName + " " + child.LastName
                }); 
            }
        }
    }
}
