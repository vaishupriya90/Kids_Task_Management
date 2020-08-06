using System;
using System.ComponentModel.DataAnnotations;

namespace Task_Management_System.ViewModel
{

    public class UserSignUpViewModel
    {
        [Required(ErrorMessage ="First Name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage ="Last Name is required")]
        public string LastName { get; set; }

        [Required]
        [Range(0,100)]
        public int Age { get; set; }

        [Required(ErrorMessage ="Please select the gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "User Name is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please select the role")]
        public string Role { get; set; }

        public UserSignUpViewModel()
        {
        }
    }
}
