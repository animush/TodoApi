using Microsoft.EntityFrameworkCore;
using ToDo.Models;
using TodoApi.Models;

namespace ToDo.Repositories
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }
        
        public DbSet<TodoItem> TodoItems { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Tool> Tools { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var todoItems = modelBuilder.Entity<TodoItem>();

        }
    }
}