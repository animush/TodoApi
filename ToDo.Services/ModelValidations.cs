using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApi.Models;

namespace ToDo.Services
{
    public class ModelValidations : IModelValidations
    {
        public bool Validate(TodoItem todoItem)
        {
            if (string.IsNullOrWhiteSpace(todoItem.Name))
                return false;
            //throw new Exception("todoItem.Name should't be empty!");
            return true;
        }
    }
}
