using System;
namespace Task_Management_System.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public User(string userName, string password, string role)
        {
            UserName = userName;
            Password = password;
            Role = role;
        }
    }
}
