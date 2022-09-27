using TodoApi.Models;

namespace ToDo.Repositories.Abstract
{
    public interface ITodoItemsRepository
    {
        Task<IEnumerable<TodoItem>> Get();
        Task<TodoItem> Get(int id);
        Task<TodoItem> Create(TodoItem todoItem);
        Task Update(int id, TodoItem TodoItem);
        Task Delete(int id);
    }
}