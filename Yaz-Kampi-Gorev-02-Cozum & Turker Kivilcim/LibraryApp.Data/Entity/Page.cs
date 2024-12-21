namespace LibraryApp.Data.Entity
{
    public class Page
    {
        public int Id { get; set; }
        public int PageNumber { get; set; }
        public int BookId { get; set; }
        public string Content { get; set; } = string.Empty;

        public Book Book { get; set; } = null!;
    }
}