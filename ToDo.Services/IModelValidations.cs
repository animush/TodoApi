﻿using ToDo.Models;

namespace ToDo.Services
{
    public interface IModelValidations
    {
        Task<bool> Validate(TodoItem todoItem);
    }
}