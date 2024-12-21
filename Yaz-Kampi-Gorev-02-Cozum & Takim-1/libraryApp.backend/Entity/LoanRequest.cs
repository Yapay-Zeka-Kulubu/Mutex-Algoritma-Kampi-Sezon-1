namespace libraryApp.backend.Entity
{
    public class LoanRequest
    {
        public int id { get; set; }
        public int userId { get; set; }
        public int bookId { get; set; }
        public DateOnly requestDate { get; set; }
        public DateOnly returnDate { get; set; }
        public bool isReturned { get; set; }
        public bool confirmation { get; set; }
        public bool pending { get; set; }

        public User? User { get; set; }
        public Book? Book { get; set; }
    }
}
