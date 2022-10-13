using Microsoft.EntityFrameworkCore;
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
            //modelBuilder.Entity<TodoItem>()
            //    .HasMany<Tool>(s => s.Tools)
            //    .WithMany(c => c.TodoItems);
        }
        public DbSet<TodoItem> TodoItems { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Tool> Tools { get; set; } = null!;
    }
}