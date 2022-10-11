using Microsoft.EntityFrameworkCore;
using ToDo.Models;
using ToDo.Models;

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
            modelBuilder.Entity<TodoItem_Tool>()
                .HasOne(i => i.TodoItem)
                .WithMany(t => t.TodoItem_Tool)
                .HasForeignKey(i => i.TodoItemId);
            modelBuilder.Entity<TodoItem_Tool>()
                .HasOne(t => t.Tool)
                .WithMany(i => i.TodoItem_Tool)
                .HasForeignKey(i => i.ToolId);
        }
        public DbSet<TodoItem> TodoItems { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Tool> Tools { get; set; } = null!;
        public DbSet<TodoItem_Tool> TodoItem_Tool { get; set; } = null!;

    }
}