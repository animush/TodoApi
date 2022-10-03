using TodoApi.Models;

namespace ToDo.Services
{
    public interface IModelValidations
    {
        Task<bool> Validate(TodoItem todoItem);
    }
}