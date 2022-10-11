using ToDo.Models;
using ToDo.Models;

namespace ToDo
{
    public static class ModelExtensions
    {
        public static TodoItem Map(this TodoItemDTO dto)
        {
            return new TodoItem
            {
                Id = dto.Id,
                Name = dto.Name,
                IsComplete = dto.IsComplete,
                ResponsibleUser = dto.ResponsibleUser,
                CreatedUser = dto.CreatedUser,
                CreatedDate = dto.CreatedDate,
                UpdatdeUser = dto.UpdatdeUser,
                UpatededDate = dto.UpatededDate
            };
        }

        public static TodoItem Map(this CreateTodoItemDTO dto)
        {
            return new TodoItem
            {
                Name = dto.Name,
                IsComplete = dto.IsComplete
            };
        }

        public static TodoItemDTO Map(this TodoItem todoItem) =>
            new TodoItemDTO
            {
                Id = todoItem.Id,
                Name = todoItem.Name,
                IsComplete = todoItem.IsComplete,
                ResponsibleUser = todoItem.ResponsibleUser,
                CreatedUser = todoItem.CreatedUser,
                CreatedDate = todoItem.CreatedDate,
                UpdatdeUser = todoItem.UpdatdeUser,
                UpatededDate = todoItem.UpatededDate

            };
        public static User Map(this UserDTO dto)
        {
            return new User
            {
                Username = dto.Username,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Password = dto.Password,
                Role = dto.Role,
            };
        }
        public static UserDTO Map(this User userModel)
        {
            return new UserDTO
            {
                Username = userModel.Username,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Password = userModel.Password,
                Role = userModel.Role,
            };
        }
        public static Tool Map(this ToolDTO dto)
        {
            return new Tool
            {
               ToolName = dto.ToolName,
            };
        }
        public static ToolDTO Map(this Tool tool)
        {
            return new ToolDTO
            {
                ToolName = tool.ToolName,
            };
        }
    }
}
