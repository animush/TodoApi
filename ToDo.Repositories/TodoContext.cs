using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Diagnostics;
using ToDo.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ToDo.Repositories
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Username = "admin",
                    FirstName = "William",
                    LastName = "Shakespeare",
                    Password = "admin",
                    Role = "Admin"
                }
            );
        }
        public DbSet<TodoItem> TodoItems { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Tool> Tools { get; set; } = null!;
    }
}