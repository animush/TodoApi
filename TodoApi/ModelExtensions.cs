using TodoApi.Models;

namespace TodoApi
{
    public static class ModelExtensions
    {
        public static TodoItem Map(this TodoItemDTO dto)
        {
            return new TodoItem
            {
                Name = dto.Name,
                IsComplete = dto.IsComplete,
                ResponsibleUser = dto.ResponsibleUser,
                CreatedUser = dto.CreatedUser,
                CreatedDate = dto.CreatedDate,
                //UpdatdeUser = dto.UpdatdeUser,
                //UpatededDate = dto.UpatededDate
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
                //UpdatdeUser = todoItem.UpdatdeUser,
                //UpatededDate = todoItem.UpatededDate

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
    }
}
