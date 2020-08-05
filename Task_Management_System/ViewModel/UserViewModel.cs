using System;
namespace Task_Management_System.ViewModel
{
    public class UserViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string SignInError { get; set; }

        public UserViewModel()
        {
        }

        public UserViewModel(string signInError)
        {
            this.SignInError = signInError;
        }
    }
}
