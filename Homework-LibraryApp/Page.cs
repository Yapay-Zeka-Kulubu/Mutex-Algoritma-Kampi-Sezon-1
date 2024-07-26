namespace LibraryManagementApp;

public class Page
{
    public int PageNumber { get; set; }
    public string? Text { get; set; }

    public Page(string text, int pageNumber)
    {
        Text = text;
        PageNumber = pageNumber;
    }
}