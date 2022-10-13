using ToDo.Models;

namespace ToDo.Services.Abstract
{
    public interface ITodoItemsService
    {
        Task<TodoItem> Create(TodoItem todoItem);
        Task<IEnumerable<TodoItem>> Get();
        Task<TodoItem> Get(int id);
        Task<List<TodoItem>> GetByUser(int userId);
        Task Update(int id, TodoItem todoItem);
        Task Delete(int id);
        Task AssignResponsibleUser(int todoItemId, int userId);
        Task AssignResponsibleTools(int itemId, IEnumerable<int> toolsId);
    }
}