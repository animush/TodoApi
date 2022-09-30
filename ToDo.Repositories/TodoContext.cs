using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
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
    }
}