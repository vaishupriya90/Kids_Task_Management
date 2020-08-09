
using Task_Management_System.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Task_Management_System.Areas.Identity.Data;

namespace Task_Management_System.Data
{
    public class ManageDbContext: IdentityDbContext<Task_Management_SystemUser>
    {
#pragma warning disable CS0114 // Member hides inherited member; missing override keyword
        public DbSet<User> Users { get; set; }
#pragma warning restore CS0114 // Member hides inherited member; missing override keyword

        public DbSet<Task> Tasks { get; set; }
 
        public ManageDbContext(DbContextOptions<ManageDbContext> options): base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }
}
