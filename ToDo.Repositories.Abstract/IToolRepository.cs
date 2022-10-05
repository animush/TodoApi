using ToDo.Models;

namespace ToDo.Repositories.Abstract
{
    public interface IToolRepository
    {
        Task<Tool> Create(Tool tool);
    }
}
