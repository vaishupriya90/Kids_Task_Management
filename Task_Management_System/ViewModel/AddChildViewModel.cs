using System;
using System.ComponentModel.DataAnnotations;

namespace Task_Management_System.ViewModel
{

    public class AddChildViewModel
    {
        [Required(ErrorMessage ="Firdt Name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage ="Last Name is required")]
        public string LastName { get; set; }

        [Required]

        [Range(0,100)]
        public string Age { get; set; }

        [Required(ErrorMessage ="Please select the gender")]
        public string Gender { get; set; }

        public AddChildViewModel()
        {
        }
    }
}
