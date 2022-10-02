using ToDo.Repositories.Abstract;
using ToDo.Services.Abstract;
using TodoApi.Models;

namespace ToDo.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository { get; set; }
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Create(User user)
        {
            return await _userRepository.Create(user);
        }

        public async Task<User> Get(int id)
        {
            return await _userRepository.Get(id);
        }
        public async Task<User> Get(string userName)
        {
            return await _userRepository.Get(userName);
        }
        public async Task Update(int id, User user)
        {
            await _userRepository.Update(id, user);
        }
        public async Task Delete(int id)
        {
            await _userRepository.Delete(id);
        }
    }
}
