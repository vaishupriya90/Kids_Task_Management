using System;
using Microsoft.AspNetCore.Identity;

namespace Task_Management_System.Areas.Identity.Data
{
    public class CustomIdentityUser:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
    }
}
