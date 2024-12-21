namespace libraryApp.backend.Entity
{
    public class Book
    {
        public int id { get; set; }
        public string title { get; set; } = string.Empty;
        public string type { get; set; } = string.Empty;
        public bool status {  get; set; }
        public int number_of_pages { get; set; }

        public List<BookAuthor> BookAuthors { get; set; } = new();
        public List<BookPublishRequest> BookPublishRequests { get; set; } = new();
        public List<LoanRequest> LoanRequest { get; set; } = new();
        public List<Page> Pages { get; set; } = new();
    }
}
