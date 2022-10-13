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
        public async Task<Tool> Get(int id)
        {
            return await _toolRepository.Get(id);
        }
        public async Task<Tool> Get(string toolName)
        {
            return await _toolRepository.Get(toolName);
        }
        public async Task Update(int id, Tool tool)
        {
            await _toolRepository.Update(id, tool);
        }
        public async Task Delete(int id)
        {
            await _toolRepository.Delete(id);
        }
    }
}
