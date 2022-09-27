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
    }
}
