using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Common.Exceptions
{
    public class EntityNotFoundException : ApplicationException
    {
        private string _message = String.Empty;
        public EntityNotFoundException(string message)
        {
            _message = message;
        }
    }
}
