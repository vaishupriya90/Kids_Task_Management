using System;
namespace Task_Management_System.Models
{
    public class Child
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        public Child()
        {
        }

        public Child(string firstName,string lastName,int age,string gender)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Gender = gender;
        }
    }
}
