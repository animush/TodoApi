using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApi.Models;

namespace ToDo.Repositories.Abstract
{
    public interface IUserRepository
    {
        Task<User> Create(User user);
        Task<User> Get (int id);
        Task<User> Get(string userName);
    }
}
