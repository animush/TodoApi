using ToDo.Models;

namespace ToDo.Services.Abstract
{
    public interface IUserService
    {
        Task<User> Create(User user);
        Task<User> Get(int id);
        Task<User> Get(string userName);
        Task Update(int id, User user);
        Task Delete(int id);
    }
}
