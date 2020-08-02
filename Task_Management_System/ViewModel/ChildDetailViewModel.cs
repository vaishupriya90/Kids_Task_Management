using System;
using Task_Management_System.Models;

namespace Task_Management_System.ViewModel
{
    public class ChildDetailViewModel
    {

        public int ChildId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

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
