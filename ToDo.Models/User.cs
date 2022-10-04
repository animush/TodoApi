namespace TodoApi.Models
{
    public class User   
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        //public User CreatedUser { get; set; }
        //public DateTime CreatedDate { get; set; }
        //public User? UpdatdeUser { get; set; }
        //public DateTime? UpatededDate { get; set; }

    }
}

