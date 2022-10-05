using ToDo.Models;
using ToDo.Repositories.Abstract;
using ToDo.Services.Abstract;

namespace ToDo.Services
{
    public class ToolService : IToolService
    {
        private IToolRepository _toolRepository { get; set; }
        public ToolService(IToolRepository toolRepository)
        {
            _toolRepository = toolRepository;
        }

        public async Task<Tool> Create(Tool tool)
        {
            return await _toolRepository.Create(tool);
        }
    }
}
