using Microsoft.AspNetCore.Mvc;
using ToDo.Services.Abstract;
using TodoApi.Models;

namespace TodoApi.Controllers
{
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
            var item = await _service.Create(toolDTO.Map());

            return CreatedAtAction(nameof(Create), item);
        }
    }
}
