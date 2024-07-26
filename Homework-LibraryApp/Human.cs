using System.ComponentModel;

namespace LibraryManagementApp;

public abstract class Human
{
    public int Id { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }

    public Human(string password, string name, string surname, int age)
    {
        //Set ID here by looking previous ones
        Password = password;
        Name = name;
        Surname = surname;
        Age = age;
        Id = Library.HumanRepo.MyList.Count + 1;
    }

    public List<Book> SearchBook(string bookName)
    {
        return Library.BookRepo.MyList.Where(b => b.Name.Contains(bookName)).ToList();
    }

    public Book ReadBook(int id)
    {
        return Library.BookRepo.MyList.Find(b => b.Id == id)!;
    }
}