using System;
using System.Collections.Generic;

namespace Task_Management_System.Models
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }

        public List<Task> Tasks { get; set; }

        public User()
        {
        }

        public User(string firstName,string lastName,int age,string gender)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Gender = gender;
        }

        public User(string firstName, string lastName, int age, string gender,string userName,string password,string role)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Gender = gender;
            UserName = userName;
            Password = password;
            Role = role;
        }
    }
}
