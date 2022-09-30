using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;
using ToDo.Services.Abstract;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> Create(UserDTO userDTO)
        {
            var item = await _service.Create(userDTO.Map());

            return CreatedAtAction(nameof(Create) ,item);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> Get(int id)
        {
            var item = await _service.Get(id);
            return Ok(item.Map());
        }
    }
}
