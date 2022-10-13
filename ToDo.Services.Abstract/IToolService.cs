using ToDo.Models;

namespace ToDo.Services.Abstract
{
    public interface IToolService
    {
        Task<Tool> Create(Tool tool);
        Task<Tool> Get(int id);
        Task<Tool> Get(string toolName);
        Task Update(int id, Tool tool);
        Task Delete(int id);
    }
}
