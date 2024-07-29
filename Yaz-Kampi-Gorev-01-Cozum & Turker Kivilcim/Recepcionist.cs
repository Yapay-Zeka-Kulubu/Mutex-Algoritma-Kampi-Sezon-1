
namespace LibraryManagementApp;

public class Recepcionist : Staff
{
    public Queue<BookRequest> BookBorrowRequests { get; set; } = new();

    public Recepcionist(List<Weekdays> workDays, string shift, string password, string name, string surname, int age) : base(workDays, shift, password, name, surname, age)
    {
    }

    public void GetBorrowRequest(Human human, Book book)
    {
        BookBorrowRequests.Enqueue(new BookRequest(book.Id, human.Id));
    }

    public void LendBookFor14Days()
    {
        BookRequest bq = BookBorrowRequests.Dequeue();
        Book book = Library.BookRepo.MyList.Find(b => b.Id == bq.BookId)!;
        book.GivenDate = DateTime.Now;
        book.IsAvailable = false;
        book.AvailableDate = DateTime.Now.AddDays(14);
        Member member = (Member) Library.HumanRepo.MyList.Find(h => h.Id == bq.HumanId)!;
        member.BorrowedBooks.Add(book);
    }

    public void TakeBookBack(Book book)
    {
        book.IsAvailable = true;
        book.GivenDate = null;
        book.AvailableDate = null;
    }

    public string SignUpMember(Member member)
    {
        Random rnd = new Random();
        member.Password = Math.Round(rnd.NextDouble() * 1000).ToString();
        AccountManager.Register(member);
        return member.Password;
    }
}