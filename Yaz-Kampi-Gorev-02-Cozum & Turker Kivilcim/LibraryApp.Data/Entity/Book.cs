using System.ComponentModel.DataAnnotations.Schema;
namespace LibraryApp.Data.Entity
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }= string.Empty;
        public bool IsPublished { get; set; }        
        [Column(TypeName = "DATE")]
        public DateTime PublishDate { get; set; }
        public bool IsBorrowed { get; set; }        

        public List<Page> Pages { get; set; } = new();
        public List<BookAuthor> BookAuthors { get; set; } = new();
        public List<BookBorrowActivity> BookBorrowActivities { get; set; } = new();
        public List<BookPublishRequest> BookPublishRequests { get; set; } = new();
    }
}