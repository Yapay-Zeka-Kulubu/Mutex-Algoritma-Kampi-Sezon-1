
namespace LibraryApp.Data.Entity
{
    public class BookAuthor
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }

        public Book Book { get; set; } = null!;
        public User User { get; set; } = null!;
    }
}