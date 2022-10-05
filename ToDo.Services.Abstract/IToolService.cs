using ToDo.Models;

namespace ToDo.Services.Abstract
{
    public interface IToolService
    {
        Task<Tool> Create(Tool tool);
    }
}
