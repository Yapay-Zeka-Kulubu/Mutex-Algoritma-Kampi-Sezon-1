
using System.ComponentModel.DataAnnotations.Schema;
namespace LibraryApp.Data.Entity
{
    public class BookBorrowActivity
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
        [Column(TypeName = "DATE")]
        public DateTime BorrowDate { get; set; }
        [Column(TypeName = "DATE")]
        public DateTime ReturnDate { get; set; }
        public bool IsApproved { get; set; }
        public bool IsReturned { get; set; }

        public Book Book { get; set; } = null!;
        public User User { get; set; } = null!;
    }
}