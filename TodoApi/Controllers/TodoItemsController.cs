using Contracts;
using Microsoft.AspNetCore.Mvc;
using ToDo.Services.Abstract;
using TodoApi.Models;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Authorization;

namespace TodoApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly ITodoItemsService _service;
        private readonly ILoggerManager _logger;

        public TodoItemsController(ITodoItemsService service, ILoggerManager logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItemDTO>>> Get()
        {
            //Test logger
            _logger.LogInfo("Here is info message from the controller.");

            var items = await _service.Get();

            return Ok(items.Select(x => x.Map()).ToArray());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItemDTO>> Get(int id)
        {
            var item = await _service.Get(id);
            return Ok(item.Map());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TodoItemDTO todoItemDTO)
        {
            await _service.Update(id, todoItemDTO.Map());

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<TodoItemDTO>> Create(TodoItemDTO todoItemDTO)
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

    }
}