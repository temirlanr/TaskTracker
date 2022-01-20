using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTracker.Entities;

namespace TaskTracker.Data
{
    public class TaskTrackerContext: DbContext
    {
        public TaskTrackerContext(DbContextOptions<TaskTrackerContext> options) : base(options) { }
        public DbSet<Project> Projects { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectTask>().HasKey(t => t.Id);
            modelBuilder.Entity<ProjectTask>().Property(t => t.Id).ValueGeneratedOnAdd().;
            modelBuilder.UseIdentityColumns();
        }
    }
}
