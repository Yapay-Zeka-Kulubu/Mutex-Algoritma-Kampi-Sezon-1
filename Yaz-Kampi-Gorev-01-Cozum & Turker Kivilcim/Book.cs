using System.Text.Json.Serialization;

namespace LibraryManagementApp;

public class Book
{
    public int Id { get; set; }
    public List<Page> Pages { get; set; }
    public List<Author> Authors { get; set; }
    public string Name { get; set; }
    public bool IsAvailable { get; set; }
    public DateTime? GivenDate { get; set; }
    public DateTime? AvailableDate { get; set; }

    [JsonIgnore]
    public TimeSpan DateLeft => (AvailableDate - GivenDate) ?? new TimeSpan();
    [JsonIgnore]
    public int PageCount => Pages.Count;

    public Book(string name, List<Page> pages, List<Author> authors)
    {
        Name = name;
        Pages = pages;
        Authors = authors;
        IsAvailable = true;
        Id = Library.BookRepo.MyList.Count + 1;
    }
}
