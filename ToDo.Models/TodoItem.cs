namespace TodoApi.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
        public User? ResponsibleUser { get; set; }
        public User? CreatedUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public User? UpdatdeUser { get; set; }
        public DateTime? UpatededDate { get; set; }

    }
}