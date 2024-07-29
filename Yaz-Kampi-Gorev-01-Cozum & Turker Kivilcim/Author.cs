
namespace LibraryManagementApp;

public class Author : Member
{
    public List<Page> CurrentPages { get; set; } = new();

    public Author(string password, string name, string surname, int age) : base(password, name, surname, age)
    {
    }

    public bool TryWritePage(string text)
    {
        string[] words = text.Split(' ');
        if (words.Length > 200) return false;
        Page newPage = new Page(text, CurrentPages.Count + 1);
        CurrentPages.Add(newPage);
        return true;
    }

    public void CreateBook(string bookName)
    {
        //because of i made it random we cannot know which manager got the request. dont stuck, no bug here just be careful
        Random rnd = new Random();
        List<Manager> managers = Library.HumanRepo.MyList.OfType<Manager>().ToList();
        Manager m = managers[rnd.Next(managers.Count)];

        Book book = new Book(bookName, CurrentPages, new List<Author> { this });
        CurrentPages = new();

        m.GetBookCreationRequest(book);
        System.Console.WriteLine("!!!Successfully requested book creation!!!");
    }

    public bool ImportPage(string path)
    {
        if (File.Exists(path) && Path.GetExtension(path) == ".txt")
        {
            string text = "";
            using (var str = new StreamReader(path))
            {
                text = str.ReadToEnd();
            }
            return TryWritePage(text);
        }
        else
            return false;
    }
}