using System;
using Microsoft.AspNetCore.Identity;

namespace Task_Management_System.Areas.Identity.Data
{
    public class Task_Management_SystemUser:IdentityUser
    {
        public string FirstName { get; set; }

    }
}
