using Contracts;
using Microsoft.AspNetCore.Mvc;
using ToDo.Services.Abstract;
using ToDo.Models;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;

namespace ToDo.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITodoItemsService _service;
        private readonly ILoggerManager _logger;

        public TodoItemsController(ITodoItemsService service, ILoggerManager logger, IMapper mapper)
        {
            _service = service;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItemDTO>>> Get()
        {
            var items = await _service.Get();

            return Ok(items.Select(x => x.Map()).ToArray());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItemDTO>> Get(int id)
        {
            var item = await _service.Get(id);
            //return Ok(item.Map());
            return Ok(_mapper.Map<TodoItemDTO>(item));
        }

        //[HttpGet("byUser/{id}")]
        //public async Task<ActionResult<IEnumerable<TodoItemDTO>>> GetByUser(int userId)
        //{
        //    //var item = await _service.Get(id);
        //    //return Ok(item.Map());
        //    throw new NotImplementedException();
        //}
        //[HttpGet("byCreationDate/{dt}")]
        //public async Task<ActionResult<IEnumerable<TodoItemDTO>>> GetByCreationDate(DateTime dt)
        //{
        //    //var item = await _service.Get(id);
        //    //return Ok(item.Map());
        //    throw new NotImplementedException();
        //}

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TodoItemDTO todoItemDTO)
        {
            await _service.Update(id, todoItemDTO.Map());

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<TodoItemDTO>> Create(CreateTodoItemDTO todoItemDTO)
        {
            var item = await _service.Create(todoItemDTO.Map());

            return CreatedAtAction(
                nameof(Get),
                new { id = item.Id },
                item.Map());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);

            return NoContent();
        }
        [HttpPatch("{itemId}/AssignUser/{userId}")]
        public async Task<IActionResult> AssignUser(int itemId, int userId)
        {
            await _service.AssignResponsibleUser(itemId, userId);

            return NoContent();
        }

    }
}