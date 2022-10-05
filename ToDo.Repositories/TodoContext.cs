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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var todoItems = modelBuilder.Entity<TodoItem>();
            var users = modelBuilder.Entity<User>();
            var tools = modelBuilder.Entity<Tool>();

            tools.ToTable("Tools");

        }
        public DbSet<TodoItem> TodoItems { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Tool> Tools { get; set; } = null!;
        
    }
}