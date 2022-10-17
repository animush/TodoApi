using ToDo.Models;

namespace ToDo.Services
{
    public class ModelValidations : IModelValidations
    {
        public async Task<bool> Validate(TodoItem todoItem)
        {
            if (string.IsNullOrWhiteSpace(todoItem.Name))
                return false;
            //throw new Exception("todoItem.Name should't be empty!");
            return true;
        }
        // TO DO: Fix
        public async Task<bool> Validate(User user)
        {
            if (string.IsNullOrWhiteSpace(user.Username))
                return false;
            //throw new Exception("todoItem.Name should't be empty!");
            return true;
        }
    }
}
