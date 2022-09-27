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

        public TodoItemsService(ITodoItemsRepository todoItemsRepository, IModelValidations validation)
        {
            _todoItemsRepository = todoItemsRepository;
            _validation = validation;
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
            await _todoItemsRepository.Update(id, todoItem);
        }

        public async Task<TodoItem> Create(TodoItem todoItem)
        {
            if (!_validation.Validate(todoItem))
                throw new Exception();


            return await _todoItemsRepository.Create(todoItem);
        }
        public async Task Delete(int id)
        {
            await _todoItemsRepository.Delete(id);
        }
        
    }
}