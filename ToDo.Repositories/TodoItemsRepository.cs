using Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using ToDo.Repositories.Abstract;
using TodoApi.Models;

namespace ToDo.Repositories
{
    public class TodoItemsRepository : ITodoItemsRepository
    {
        private readonly ILoggerManager _logger;
        private readonly TodoContext _context;
        public TodoItemsRepository(TodoContext context, ILoggerManager logger)
        {
            _context = context;
            _logger = logger;
        }
        
        public async Task<IEnumerable<TodoItem>> Get()
        {
            return await _context.TodoItems
                    .ToListAsync();
        }
        
        public async Task<TodoItem> Get(int id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);
            
            if (todoItem == null) throw new Exception($"TodoItem with id = {id} doesn't exists");
               
            return todoItem;
        }

        public async Task Update(int id, TodoItem todoItem)
        {
            var todoItemEx = await _context.TodoItems.FindAsync(id);
            if (todoItemEx == null) throw new Exception($"TodoItem with id = {id} doesn't exists");
            todoItemEx.Name = todoItem.Name;
            todoItemEx.IsComplete = todoItem.IsComplete;
            await _context.SaveChangesAsync();
        }

        public async Task<TodoItem> Create(TodoItem todoItem)
        {
            

            _context.TodoItems.Add(todoItem);
            
            await _context.SaveChangesAsync();
           
            return todoItem;
        }
        public async Task Delete(int id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);

            if (todoItem == null)
            {
                throw new Exception($"TodoItem with id = {id} doesn't exists");
            }

            _context.TodoItems.Remove(todoItem);
            await _context.SaveChangesAsync();
        }
    }
}