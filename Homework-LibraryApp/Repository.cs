namespace LibraryManagementApp;

public class Repository<T>
{
    public readonly List<T> MyList;

    public Repository()
    {
        MyList = new List<T>();
    }
}