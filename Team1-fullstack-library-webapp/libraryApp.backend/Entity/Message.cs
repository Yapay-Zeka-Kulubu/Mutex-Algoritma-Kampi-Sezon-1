namespace libraryApp.backend.Entity
{
    public class Message
    {
        public int id { get; set; }
        public int senderId { get; set; }
        public int recieverId { get; set; }
        public string title { get; set; } = string.Empty;
        public string content { get; set; } = string.Empty;
        public DateOnly sendingDate { get; set; }
        public bool isRead { get; set; }

        public User? sender { get; set; }
    }
}
