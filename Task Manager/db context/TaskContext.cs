using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Task_Manager.Entity;

namespace Task_Manager.db_context
{
    public class TaskContext : DbContext
    {
        public DbSet<Task> Task { get; set; }

        public TaskContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=taskdb;Trusted_Connection=True;");
        }
    }
}
