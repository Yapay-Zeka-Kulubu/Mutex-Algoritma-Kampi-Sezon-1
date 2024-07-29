namespace LibraryManagementApp;

public class BookRequest
{
    public int BookId { get; set; }
    public int HumanId { get; set; }

    public BookRequest(int bookId, int humanId)
    {
        BookId = bookId;
        HumanId = humanId;
    }
}