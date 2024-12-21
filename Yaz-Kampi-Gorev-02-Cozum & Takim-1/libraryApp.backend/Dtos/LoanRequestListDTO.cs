public class LoanRequestListDTO
{
    public int bookId {get;set;}
    public DateOnly requestDate { get; set; }
        public DateOnly returnDate { get; set; }
        public List<string> BookAuthors { get; set; } = new();
        public string title { get; set; } = string.Empty;
}