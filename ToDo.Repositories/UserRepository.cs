using Microsoft.EntityFrameworkCore;
using ToDo.Repositories.Abstract;
using TodoApi.Models;

namespace ToDo.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TodoContext _context;
        public UserRepository(TodoContext context)
        {
            _context = context;
        }
        public async Task<User> Create(User user)
        {
            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            return user;
        }
        public async Task<User> Get(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) throw new Exception($"User with id = {id} doesn't exists");
            return user;
        }
        public async Task<User> Get(string userName)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Username == userName);
        }
    }
}
