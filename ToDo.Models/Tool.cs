namespace ToDo.Models
{
    public class Tool
    {
        public int Id { get; set; }
        public string ToolName { get; set; }

        // Navigations properties

        public List<TodoItem_Tool> TodoItem_Tool { get; set; }

    }
}
