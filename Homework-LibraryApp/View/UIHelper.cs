namespace LibraryManagementApp.View;

public static class UIHelper
{
    public static int GetValidInteger()
    {
        int num = 0;
        bool isNum = int.TryParse(Console.ReadLine(), out num);
        while (!isNum)
        {
            System.Console.WriteLine("Please enter a number!");
            isNum = int.TryParse(Console.ReadLine(), out num);
        }
        return num;
    }

    public static int GetValidIntWithinRange(int inclusiveStart, int exclusiveEnd)
    {
        int num = GetValidInteger();
        bool isWithinRange = exclusiveEnd > num && num >= inclusiveStart;
        while (!isWithinRange)
        {
            System.Console.WriteLine();
            System.Console.WriteLine("!!!Enter a number within the range!!!");
            num = GetValidInteger();
            isWithinRange = exclusiveEnd > num && num >= inclusiveStart;
        }
        return num;
    }

    public static void ReadBook(Book book)
    {
        int page = 0;
        do
        {
            System.Console.WriteLine();
            System.Console.WriteLine("This book is " + book.PageCount + " pages long. Enter page number to read or 0 to exit");
            page = UIHelper.GetValidIntWithinRange(0, book.PageCount + 1);

            if (page == 0) continue;
            string text = book.Pages[page - 1].Text ?? "";
            System.Console.WriteLine("----------------Page " + page + "----------------");
            System.Console.WriteLine(text);
            System.Console.WriteLine("----------------Page " + page + "----------------");
        }
        while (page != 0);
    }
}