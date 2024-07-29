
namespace LibraryManagementApp;

public class Manager : Staff
{
    public Queue<Book> PendingBooksToCreate { get; set; } = new();

    public Manager(List<Weekdays> workDays, string shift, string password, string name, string surname, int age) : base(workDays, shift, password, name, surname, age)
    {

    }

    public void GetBookCreationRequest(Book book)
    {
        PendingBooksToCreate.Enqueue(book);
    }

    public void AddBookToLibrary()
    {
        Library.BookRepo.MyList.Add(PendingBooksToCreate.Dequeue());
    }

    public void RemoveBookFromLibrary(Book book)
    {
        Library.BookRepo.MyList.Remove(book);
    }

    public bool TryHireStaff(Human human, List<Weekdays> workdays, string shift)
    {
        if (human is Staff staff) return false;

        Library.HumanRepo.MyList.Remove(human);
        Recepcionist recepcionist = new Recepcionist(workdays, shift, human.Password, human.Name, human.Surname, human.Age);
        recepcionist.Id = human.Id;
        Library.HumanRepo.MyList.Add(recepcionist);
        return true;
    }

    public void FireStaff(Staff staff)
    {
        Library.HumanRepo.MyList.Remove(staff);
    }
}