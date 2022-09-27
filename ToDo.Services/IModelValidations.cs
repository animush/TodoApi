using TodoApi.Models;

namespace ToDo.Services
{
    public interface IModelValidations
    {
        bool Validate(TodoItem todoItem);
    }
}