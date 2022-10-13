namespace ToDo.Models
{
    public class Tool
    {
        public int Id { get; set; }
        public string ToolName { get; set; }
        public virtual ICollection<TodoItem> TodoItems { get; set; }
    }
}
