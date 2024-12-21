namespace libraryApp.backend.Entity
{
    public class BookPublishRequest
    {
        public int id { get; set; }
        public int userId { get; set; }
        public int bookId { get; set; }
        public DateOnly requestDate { get; set; }
        public bool confirmation { get; set; }
        public bool pending { get; set; }

        public User? User { get; set; }
        public Book? Book { get; set; }
    }
}
