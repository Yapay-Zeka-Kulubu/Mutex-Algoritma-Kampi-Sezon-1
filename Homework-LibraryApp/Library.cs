namespace LibraryManagementApp;

public static class Library
{
    public static Repository<Book> BookRepo = new();
    public static Repository<Human> HumanRepo = new();
}