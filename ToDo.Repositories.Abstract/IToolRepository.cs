using ToDo.Models;

namespace ToDo.Repositories.Abstract
{
    public interface IToolRepository
    {
        Task<Tool> Create(Tool tool);
        Task<Tool> Get(int toolId);
        Task<Tool> Get(IEnumerable<int> ids);
        Task<Tool> Get(string toolName);
        Task Update(int id, Tool tool);
        Task Delete(int id);
    }
}
