﻿using TodoApi.Models;

namespace TodoApi
{
    public static class ModelExtensions
    {
        public static TodoItem Map(this TodoItemDTO dto)
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
                IsComplete = todoItem.IsComplete
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
