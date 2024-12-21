namespace libraryApp.backend.Entity
{
    public class User
    {
        public int id { get; set; }
        public int roleId { get; set; }
        public string name { get; set; } = string.Empty;
        public string surname { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string username { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public bool userStatus { get; set; }

        public Role? Role { get; set; } = null;

        public List<BookAuthor> BookAuthors { get; set; } = new();
        public List<BookPublishRequest> BookPublisRequests { get; set; } = new();
        public List<LoanRequest> LoanRequests { get; set; } = new();
        public List<Message> Messages { get; set; } = new();
        public List<Point> Points { get; set; } = new();
        public List<Punishment> Punishments { get; set; } = new();
        public List<RegisterRequest> RegisterRequests { get; set; } = new();
    }
}
