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
    }
}
