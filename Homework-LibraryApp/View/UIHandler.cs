using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementApp.View;

public class UIHandler
{
    public void RunTheApp()
    {
        System.Console.WriteLine("Welcome to the library!");

        ConsoleKey inputKey = ConsoleKey.None;
        while (inputKey != ConsoleKey.Escape)
        {
            System.Console.WriteLine();
            System.Console.WriteLine("Here is the list of operations you can do: ");
            System.Console.WriteLine();

            //GİVE BORROWED BOOK BACK
            if (AccountManager.IsLoggedIn)
            {
                if (AccountManager.CurrentHuman is Member member)
                {
                    System.Console.WriteLine("1- Search book by name"); //OK
                    System.Console.WriteLine("2- Borrow book by Id"); //OK
                    System.Console.WriteLine("3- Give borrowed book back"); //OK
                }
                if (AccountManager.CurrentHuman is Author author)
                {
                    System.Console.WriteLine("4- Write a page"); //OK
                    System.Console.WriteLine("5- Turn all pages into book"); //OK
                    System.Console.WriteLine("6- Import a page from text file");
                }
                if (AccountManager.CurrentHuman is Recepcionist recepcionist)
                {
                    System.Console.WriteLine("1- Register a member"); //OK
                    System.Console.WriteLine("2- See pending borrow request"); //OK
                }
                if (AccountManager.CurrentHuman is Manager manager)
                {
                    System.Console.WriteLine("1- Change role of someone"); //OK
                    System.Console.WriteLine("2- See pending book creation request"); //OK
                }

                System.Console.WriteLine("8- Change Password"); //OK
                System.Console.WriteLine("9- Read a book"); //OK
                System.Console.WriteLine("0- Logout"); //OK
            }
            else
            {
                System.Console.WriteLine("1- Login"); //OK
                System.Console.WriteLine("ESC- Exit"); //OK
            }

            inputKey = Console.ReadKey().Key;
            ProcessInputKey(inputKey);
        }
    }

    private void ProcessInputKey(ConsoleKey inputKey)
    {
        if (AccountManager.IsLoggedIn)
        {
            switch (AccountManager.CurrentHuman)
            {
                case Author author:
                    switch (inputKey)
                    {
                        case ConsoleKey.D1:
                            SearchBookUI(author);
                            break;
                        case ConsoleKey.D2:
                            BorrowBookUI(author);
                            break;
                        case ConsoleKey.D3:
                            GiveBorrowedBookBackUI(author);
                            break;
                        case ConsoleKey.D4:
                            WritePageUI(author);
                            break;
                        case ConsoleKey.D5:
                            CreateBookUI(author);
                            break;
                        case ConsoleKey.D6:
                            ImportPageUI(author);
                            break;
                    }
                    break;
                case Member member:
                    switch (inputKey)
                    {
                        case ConsoleKey.D1:
                            SearchBookUI(member);
                            break;
                        case ConsoleKey.D2:
                            BorrowBookUI(member);
                            break;
                        case ConsoleKey.D3:
                            GiveBorrowedBookBackUI(member);
                            break;
                    }
                    break;
                case Recepcionist recepcionist:
                    switch (inputKey)
                    {
                        case ConsoleKey.D1:
                            RegisterUI(recepcionist);
                            break;
                        case ConsoleKey.D2:
                            SeeBorrowRequestsUI(recepcionist);
                            break;
                    }
                    break;
                case Manager manager:
                    switch (inputKey)
                    {
                        case ConsoleKey.D1:
                            ChangeRoleOfSomeoneUI();
                            break;
                        case ConsoleKey.D2:
                            ReadBookUI(manager);
                            break;
                    }
                    break;

            }
            switch (inputKey)
            {
                case ConsoleKey.D8:
                    ChangePasswordUI();
                    break;
                case ConsoleKey.D9:
                    ReadBookUI(AccountManager.CurrentHuman!);
                    break;
                case ConsoleKey.D0:
                    AccountManager.Logout();
                    break;
            }
        }
        else
        {
            switch (inputKey)
            {
                case ConsoleKey.D1:
                    LoginUI();
                    break;
            }
        }
    }

    private void LoginUI()
    {
        System.Console.WriteLine();
        System.Console.WriteLine("Enter your ID: ");
        int id = UIHelper.GetValidInteger();
        System.Console.WriteLine();
        System.Console.WriteLine("Enter your password: ");
        string password = Console.ReadLine() ?? "";
        if (AccountManager.Login(id, password))
        {
            Human human = AccountManager.CurrentHuman!;
            System.Console.WriteLine($"!!!Welcome {human.Name}!!!");
        }
        else
        {
            System.Console.WriteLine("!!!Password or id is incorrect!!!");
        }
    }

    private void RegisterUI(Recepcionist rece)
    {
        System.Console.WriteLine();
        System.Console.WriteLine("Enter member's name: ");
        string name = Console.ReadLine() ?? "";
        System.Console.WriteLine();
        System.Console.WriteLine("Enter member's surname: ");
        string surname = Console.ReadLine() ?? "";
        System.Console.WriteLine();
        System.Console.WriteLine("Enter member's age: ");
        int age = UIHelper.GetValidInteger();

        Member? member = new Member("", name, surname, age);
        string temppass = rece.SignUpMember(member);

        System.Console.WriteLine();
        System.Console.WriteLine("!!!Signed up. Here is the temporary password of member: " + temppass + " !!!");
    }

    private void WritePageUI(Author author)
    {
        System.Console.WriteLine();
        System.Console.WriteLine("!!!You can start writing now.!!!");
        string text = Console.ReadLine() ?? "";
        while (!author.TryWritePage(text))
        {
            System.Console.WriteLine();
            System.Console.WriteLine("!!!Please don't exceed 200 words!!!");
            text = Console.ReadLine() ?? "";
        }
    }

    private void CreateBookUI(Author author)
    {
        if (author.CurrentPages.Count == 0)
        {
            System.Console.WriteLine();
            System.Console.WriteLine("!!!You didn't write a single page!!!");
            return;
        }

        System.Console.WriteLine();
        System.Console.WriteLine("Enter book's name: ");
        string name = Console.ReadLine() ?? "";
        author.CreateBook(name);
    }

    private void SearchBookUI(Human human)
    {
        System.Console.WriteLine();
        System.Console.WriteLine("Search book by name: ");
        string input = Console.ReadLine() ?? "";
        List<Book> books = human.SearchBook(input);
        if (books == null || books.Count == 0)
        {
            System.Console.WriteLine();
            System.Console.WriteLine("!!!There is no book associated with your input!!!");
            return;
        }

        System.Console.WriteLine();
        System.Console.WriteLine("Here is the book/s that matches your input: (Max 5 book)");
        foreach (var b in books.GetRange(0, Math.Min(5, books.Count)))
        {
            System.Console.WriteLine("---------------------");
            System.Console.WriteLine($"Book Id: {b.Id}\nBook name: {b.Name}\nAuthor: {String.Join(' ', b.Authors.Select(a => a.Name))}\nPage: {b.PageCount}\nAvailable to borrow?: {b.IsAvailable}\n" + (b.IsAvailable ? "" : "Date left to be available: " + b.DateLeft.Days + " Days"));
        }
    }

    private void BorrowBookUI(Member member)
    {
        System.Console.WriteLine();
        System.Console.WriteLine("Enter the id of book you wanna borrow: ");
        int id = UIHelper.GetValidIntWithinRange(1, Library.BookRepo.MyList.Count + 1);
        bool result = member.TryBorrowBook(id);
        if (result)
        {
            System.Console.WriteLine();
            System.Console.WriteLine("!!!Request arrived. Wait for the recepcionist's approval!!!");
        }
        else
        {
            System.Console.WriteLine();
            System.Console.WriteLine("!!!You tried to borrow book that already borrowed. Please wait!!!");
        }
    }

    //for members to read
    private void ReadBookUI(Human human)
    {
        Book? book = null;
        int id = 0;

        if (human is Member member)
        {
            if (member.BorrowedBooks.Count == 0)
            {
                System.Console.WriteLine();
                System.Console.WriteLine("!!!You don't have any borrowed book!!!");
                return;
            }
            System.Console.WriteLine();
            System.Console.WriteLine("Here is the list of borrowed books by you: ");
            foreach (var b in member.BorrowedBooks)
            {
                System.Console.WriteLine("----------------------");
                System.Console.WriteLine($"{b.Id}- {b.Name}");
            }

            System.Console.WriteLine();
            System.Console.WriteLine("Enter book's Id:");

            id = UIHelper.GetValidInteger();
            while (!member.BorrowedBooks.Select(b => b.Id).Contains(id))
            {
                System.Console.WriteLine("!!!Enter valid ID!!!");
                id = UIHelper.GetValidInteger();
            }

            book = member.ReadBook(id);
        }
        else
        {
            System.Console.WriteLine();
            System.Console.WriteLine("Enter book's Id: ");

            id = UIHelper.GetValidIntWithinRange(1, Library.BookRepo.MyList.Count + 1);
            book = human.ReadBook(id);
        }

        UIHelper.ReadBook(book);
    }

    //for managers to check new book
    private void ReadBookUI(Manager manager)
    {
        if (manager.PendingBooksToCreate.Count == 0)
        {
            System.Console.WriteLine();
            System.Console.WriteLine("!!!There is no pending requests!!!");
            return;
        }
        Book book = manager.PendingBooksToCreate.Peek();

        System.Console.WriteLine();
        System.Console.WriteLine($"Infos about book: Name: {book.Name}, Author: {String.Join(' ', book.Authors.Select(a => a.Name))}");
        System.Console.WriteLine();
        UIHelper.ReadBook(book);
        System.Console.WriteLine();
        System.Console.WriteLine("Do you want to add this book to library? (y/n)");

        var key = Console.ReadKey().Key;
        if (key == ConsoleKey.Y)
        {
            System.Console.WriteLine();
            System.Console.WriteLine("!!!Book added!!!");
            manager.AddBookToLibrary();
        }
        else if (key == ConsoleKey.N)
        {
            System.Console.WriteLine();
            System.Console.WriteLine("!!!Book removed!!!");
            manager.PendingBooksToCreate.Dequeue();
        }
    }

    private void SeeBorrowRequestsUI(Recepcionist recepcionist)
    {
        if (recepcionist.BookBorrowRequests.Count == 0)
        {
            System.Console.WriteLine();
            System.Console.WriteLine("!!!There is no pending requests!!!");
            return;
        }
        BookRequest bookReq = recepcionist.BookBorrowRequests.Peek();
        Book book = Library.BookRepo.MyList.Find(b => b.Id == bookReq.BookId)!;
        Member member = (Member)Library.HumanRepo.MyList.Find(h => h.Id == bookReq.HumanId)!;

        if (!book.IsAvailable)
        {
            System.Console.WriteLine();
            System.Console.WriteLine($"!!!Member named{member.Name} is want to borrow the book called {book.Name} but someone borrowed book first. So request is being deleted!!!");
            recepcionist.BookBorrowRequests.Dequeue();
            return;
        }

        System.Console.WriteLine();
        System.Console.WriteLine($"Member named {member.Name} is want to borrow the book called {book.Name}. Do you want to accept? (y/n)");
        var key = Console.ReadKey().Key;
        if (key == ConsoleKey.Y)
        {
            System.Console.WriteLine();
            System.Console.WriteLine("!!!Request approved!!!");
            recepcionist.LendBookFor14Days();
        }
        else if (key == ConsoleKey.N)
        {
            System.Console.WriteLine();
            System.Console.WriteLine("!!!Request removed!!!");
            recepcionist.BookBorrowRequests.Dequeue();
        }
    }

    private void ChangePasswordUI()
    {
        System.Console.WriteLine();
        System.Console.WriteLine("Enter the new password: ");
        string newPassword = Console.ReadLine() ?? "";
        AccountManager.ChangePassword(newPassword);
        System.Console.WriteLine("Your new password is: " + newPassword + " Please dont share with someone else.");
    }

    private void ChangeRoleOfSomeoneUI()
    {
        System.Console.WriteLine();
        System.Console.WriteLine("Enter the id of user you wanna change role of: ");
        int id = UIHelper.GetValidIntWithinRange(1, Library.HumanRepo.MyList.Count + 1);
        while (id == AccountManager.CurrentHuman!.Id)
        {
            System.Console.WriteLine();
            System.Console.WriteLine("!!!You cannot select yourself!!!");
            id = UIHelper.GetValidIntWithinRange(1, Library.HumanRepo.MyList.Count + 1);
        }
        Human human = Library.HumanRepo.MyList.Find(h => h.Id == id)!;
        if (human is Member member)
        {
            member.BorrowedBooks.ForEach(b => member.GiveBookBack(b.Id));
        }
        System.Console.WriteLine("Which role you want to turn into?");
        System.Console.WriteLine("1- Member\n2- Author\n3- Recepcionist\n4- Manager");
        var key = Console.ReadKey().Key;
        while (!new ConsoleKey[] { ConsoleKey.D1, ConsoleKey.D2, ConsoleKey.D3, ConsoleKey.D4 }.Contains(key))
        {
            key = Console.ReadKey().Key;
        }

        Library.HumanRepo.MyList.Remove(human);
        Human? newRole = null;
        switch (key)
        {
            case ConsoleKey.D1:
                newRole = new Member(human.Password, human.Name, human.Surname, human.Age)
                {
                    Id = human.Id
                };
                break;
            case ConsoleKey.D2:
                newRole = new Author(human.Password, human.Name, human.Surname, human.Age)
                {
                    Id = human.Id
                };
                break;
            case ConsoleKey.D3:
                newRole = new Recepcionist(new List<Weekdays> { }, "", human.Password, human.Name, human.Surname, human.Age)
                {
                    Id = human.Id,
                };
                break;
            case ConsoleKey.D4:
                newRole = new Manager(new List<Weekdays> { }, "", human.Password, human.Name, human.Surname, human.Age)
                {
                    Id = human.Id,
                };
                break;
        }

        Library.HumanRepo.MyList.Add(newRole!);
        System.Console.WriteLine();
        System.Console.WriteLine("!!!Successful!!!");
    }

    private void GiveBorrowedBookBackUI(Member member)
    {
        if (member.BorrowedBooks.Count == 0)
        {
            System.Console.WriteLine();
            System.Console.WriteLine("!!!You don't have any borrowed book!!!");
            return;
        }

        System.Console.WriteLine("Here is the list of borrowed books by you: ");
        foreach (var b in member.BorrowedBooks)
        {
            System.Console.WriteLine("----------------------");
            System.Console.WriteLine($"{b.Id}- {b.Name}");
        }

        System.Console.WriteLine();
        System.Console.WriteLine("Enter book's Id: ");

        int id = UIHelper.GetValidInteger();
        while (!member.BorrowedBooks.Select(b => b.Id).Contains(id))
        {
            System.Console.WriteLine("!!!Enter valid ID!!!");
            id = UIHelper.GetValidInteger();
        }

        member.GiveBookBack(id);
        System.Console.WriteLine("!!!Successful!!!");
    }

    void ImportPageUI(Author author)
    {
        System.Console.WriteLine();
        System.Console.WriteLine("You can only select text file and all the text inside the file will be saved as one page, appended to the current pages.");
        Thread.Sleep(2000);
        System.Console.WriteLine("Enter the path of text file: ");
        string path = Console.ReadLine() ?? "";
        System.Console.WriteLine(path);
        if (author.ImportPage(path))
        {
            System.Console.WriteLine();
            System.Console.WriteLine("!!!Successfully saved!!!");
        }
        else
        {
            System.Console.WriteLine();
            System.Console.WriteLine("Here is the list of errors happened during the importing session");
            System.Console.WriteLine("!!!There is no text file in that path!!!");
            System.Console.WriteLine("!!!The words exceeds 200 words limit!!!");
            System.Console.WriteLine("!!!File is not a text(.txt) file!!!");
        }
    }
}