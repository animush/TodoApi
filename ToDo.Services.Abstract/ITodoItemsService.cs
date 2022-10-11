using ToDo.Models;

namespace ToDo.Services.Abstract
{
    public interface ITodoItemsService
    {
        Task<TodoItem> Create(TodoItem todoItem);
        Task<IEnumerable<TodoItem>> Get();
        Task<TodoItem> Get(int id);
        Task Update(int id, TodoItem todoItem);
        Task Delete(int id);
        Task AssignResponsibleUser(int todoItemId, int userId);
    }
}