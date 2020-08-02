﻿
using Task_Management_System.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Task_Management_System.Data
{
    public class ManageDbContext:DbContext
    {
        public DbSet<Child> Children { get; set; }

        public ManageDbContext(DbContextOptions<ManageDbContext> options): base(options)
        {

        }
    }
}