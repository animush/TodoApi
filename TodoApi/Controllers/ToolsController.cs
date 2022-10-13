using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDo.Services.Abstract;
using ToDo.Models;

namespace ToDo.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ToolsController :  ControllerBase
    {
        private readonly IToolService _service;
        public ToolsController(IToolService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<ActionResult<ToolDTO>> Create(ToolDTO toolDTO)
        {
            var tool = await _service.Create(toolDTO.Map());

            return CreatedAtAction(nameof(Create), tool);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ToolDTO>> Get(int id)
        {
            var tool = await _service.Get(id);
            return Ok(tool.Map());
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ToolDTO toolDTO)
        {
            await _service.Update(id, toolDTO.Map());

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);

            return NoContent();
        }

    }
}
