using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Models;
using ToDo.Repositories.Abstract;
using TodoApi.Models;

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
    }
}
