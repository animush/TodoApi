using System.Runtime.CompilerServices;
using ToDo.Repositories;
using ToDo.Repositories.Abstract;
using ToDo.Services;
using ToDo.Services.Abstract;
using ToDo.Models;

namespace ToDo.Services
{
    public class TodoItemsService : ITodoItemsService
    {
        private IModelValidations _validation { get; set; }
        private ITodoItemsRepository _todoItemsRepository { get; set; }
        private IUserRepository _userRepository { get; set; }
        private readonly UserContext _userContext;
        private ITodoItemsRepository object1;
        private IModelValidations object2;
        private IUserRepository object3;
        private UserContext object4;

        private IToolRepository _toolRepository { get; set; }

        public TodoItemsService(ITodoItemsRepository todoItemsRepository, IModelValidations validation, IUserRepository userRepository, UserContext userContext, IToolRepository toolRepository)
        {
            _todoItemsRepository = todoItemsRepository;
            _validation = validation;
            _userRepository = userRepository;
            _userContext = userContext;
            _toolRepository = toolRepository;
        }

        public TodoItemsService(ITodoItemsRepository object1, IModelValidations object2, IUserRepository object3, UserContext object4)
        {
            this.object1 = object1;
            this.object2 = object2;
            this.object3 = object3;
            this.object4 = object4;
        }

        public async Task<IEnumerable<TodoItem>> Get()
        {
            return await _todoItemsRepository.Get();
        }

        public async Task<TodoItem> Get(int id)
        {
            return await _todoItemsRepository.Get(id);
        }
        public async Task<List<TodoItem>> GetByUser(int userId)
        {
            return await _todoItemsRepository.GetByUser(userId);
        }

        public async Task Update(int id, TodoItem todoItem)
        {
            todoItem.UpatededDate = DateTime.Now;
            todoItem.UpdatdeUser = await _userRepository.Get(_userContext.CurrentUserId);

            await _todoItemsRepository.Update(id, todoItem);
        }

        public async Task<TodoItem> Create(TodoItem todoItem)
        {
            if (!await _validation.Validate(todoItem))
                throw new Exception();

            todoItem.CreatedDate = DateTime.Now;
            todoItem.CreatedUser = await _userRepository.Get(_userContext.CurrentUserId);

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

        public async Task AssignResponsibleTools(int itemId, IEnumerable<int> toolsId)
        {
            var item = await _todoItemsRepository.Get(itemId);
            var list = new List<Tool>();
            foreach (var toolId in toolsId)
            {
                var tool = await _toolRepository.Get(toolId);
                list.Add(tool);
            }
            item.Tools = list;
            await _todoItemsRepository.Update(itemId, item);
        }
    }
}