using System.Runtime.CompilerServices;
using ToDo.Repositories;
using ToDo.Repositories.Abstract;
using ToDo.Services;
using ToDo.Services.Abstract;
using TodoApi.Models;

namespace TodoApi.Services
{
    public class TodoItemsService : ITodoItemsService
    {
        private IModelValidations _validation { get; set; }

        private ITodoItemsRepository _todoItemsRepository { get; set; }
        private IUserRepository _userRepository { get; set; }

        public TodoItemsService(ITodoItemsRepository todoItemsRepository, IModelValidations validation, IUserRepository userRepository)
        {
            _todoItemsRepository = todoItemsRepository;
            _validation = validation;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<TodoItem>> Get()
        {
            return await _todoItemsRepository.Get();
        }

        public async Task<TodoItem> Get(int id)
        {
            return await _todoItemsRepository.Get(id);
        }


        public async Task Update(int id, TodoItem todoItem)
        {
            //!
            todoItem.UpatededDate = DateTime.Now;
            todoItem.CreatedUser = await _userRepository.Get(UserContext.CurrentUserId);

            await _todoItemsRepository.Update(id, todoItem);
        }

        public async Task<TodoItem> Create(TodoItem todoItem)
        {
            if (!_validation.Validate(todoItem))
                throw new Exception();

            todoItem.CreatedDate = DateTime.Now;
            todoItem.CreatedUser = await _userRepository.Get(UserContext.CurrentUserId);

            return await _todoItemsRepository.Create(todoItem);
        }
        public async Task Delete(int id)
        {
            await _todoItemsRepository.Delete(id);
        }

        public async Task AssignResponsibleUser(int todoItemId, int userId)
        {
            var item = await _todoItemsRepository.Get(todoItemId);
            var user = await _userRepository.Get(userId);
            item.ResponsibleUser = user;
            await _todoItemsRepository.Update(todoItemId, item);
        }
    }
}