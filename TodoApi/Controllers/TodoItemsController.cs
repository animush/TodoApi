﻿using Contracts;
using Microsoft.AspNetCore.Mvc;
using ToDo.Services.Abstract;
using ToDo.Models;
using System.Data;
using AutoMapper;
using System;
using System.Net;
using System.IO;
using System.Text;
using NuGet.Protocol;

namespace ToDo.Controllers
{
    //[Authorize]
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

            return Ok(_mapper.Map<TodoItemDTO>(item));
        }

        [HttpGet("byUser/{id}")]
        public async Task<ActionResult<List<TodoItemDTO>>> GetByUser(int userId)
        {
            var items = await _service.GetByUser(userId);
            return Ok(items.Select(x => x.Map()).ToArray());
        }
        
        [HttpGet("GetLocation")]
        public async Task<ActionResult> GetLocation()
        {


            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            //var userIp = "46.201.7.98";
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"https://ipapi.co/{userIp}/json/");
            //request.UserAgent = "ipapi.co/#c-sharp-v1.03";
            //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //var reader = new System.IO.StreamReader(response.GetResponseStream(), UTF8Encoding.UTF8);
            //reader.ReadToEnd()
            return Ok();
        }
        

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
        [HttpPatch("{itemId}/AssignTool/")]
        public async Task<IActionResult> AssignTools(int itemId, IEnumerable<int> toolsId)
        {
            await _service.AssignTools(itemId, toolsId);

            return NoContent();
        }

    }
}