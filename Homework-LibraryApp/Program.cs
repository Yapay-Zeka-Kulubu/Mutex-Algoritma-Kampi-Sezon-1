using LibraryManagementApp;
using LibraryManagementApp.View;

internal class Program
{
    private static void Main(string[] args)
    {
        DatabaseManager.LoadAllRepos();

        UIHandler uIHandler = new UIHandler();
        uIHandler.RunTheApp();
        
        DatabaseManager.SaveAllRepos();
    }
}