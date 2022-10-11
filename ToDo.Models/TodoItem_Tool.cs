using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Models
{
    public class TodoItem_Tool
    {
        public int Id { get; set; }
        public int TodoItemId { get; set; }
        public TodoItem TodoItem { get; set; }
        public int ToolId { get; set; }
        public Tool Tool { get; set; }
    }
}
