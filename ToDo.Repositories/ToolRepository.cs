﻿using Microsoft.EntityFrameworkCore;
using ToDo.Models;
using ToDo.Repositories.Abstract;

namespace ToDo.Repositories
{
    public class ToolRepository : IToolRepository
    {
        private readonly TodoContext _context;
        public ToolRepository(TodoContext context)
        {
            _context = context;
        }

        public async Task<Tool> Create(Tool tool)
        {
            _context.Tools.Add(tool);

            await _context.SaveChangesAsync();

            return tool;
        }
        public async Task<Tool> Get(int id)
        {
            var tool = await _context.Tools.FindAsync(id);
            if (tool == null) throw new Exception($"Tool with id = {id} doesn't exists");
            return tool;
        }

        public async Task<Tool> Get(IEnumerable<int> ids)
        {
            var tool = await _context.Tools.FindAsync(ids);
            if (tool == null) throw new Exception($"Tool with id = {ids} doesn't exists");
            return tool;
        }

        public async Task<Tool> Get(string toolName)
        {
            return await _context.Tools.FirstOrDefaultAsync(x => x.ToolName == toolName);
        }
        public async Task Delete(int id)
        {
            var tool = await _context.Tools.FindAsync(id);

            if (tool == null)
            {
                throw new Exception($"User with id = {id} doesn't exists");
            }

            _context.Tools.Remove(tool);
            await _context.SaveChangesAsync();
        }
        public async Task Update(int id, Tool tool)
        {
            var toolEx = await _context.Tools.FindAsync(id);
            if (toolEx == null) throw new Exception($"Tool with id = {id} doesn't exists");
            toolEx.ToolName = tool.ToolName;
            await _context.SaveChangesAsync();
        }

    }
}
