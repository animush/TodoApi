﻿using TodoApi.Models;

namespace ToDo.Services.Abstract
{
    public interface IUserService
    {
        Task<User> Create(User user);
        Task<User> Get(int id);
        Task<User> Get(string userName);
    }
}
