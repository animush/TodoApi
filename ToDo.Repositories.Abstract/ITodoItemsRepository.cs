using ToDo.Models;

namespace ToDo.Repositories.Abstract
{
    public interface ITodoItemsRepository
    {
        Task<TodoItem> Create(TodoItem todoItem);
        Task<IEnumerable<TodoItem>> Get();
        Task<TodoItem> Get(int id);
        Task<List<TodoItem>> GetByUser(int userId);
        Task Update(int id, TodoItem todoItem);
        Task Delete(int id);
    }
}