using System;

class BookShelfMenu
{
    private IBookShelfOperations shelf;

    public BookShelfMenu()
    {
        shelf = new BookShelfUtilityImpl();
    }

    public void Start()
    {
        int choice;

        do
        {
            Console.WriteLine("\n===== BOOK SHELF MENU =====");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Borrow Book");
            Console.WriteLine("3. Return Book");
            Console.WriteLine("4. Display Books By Genre");
            Console.WriteLine("5. Display Entire Catalog");
            Console.WriteLine("0. Exit");
            Console.Write("Enter choice: ");

            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddBookFlow();
                    break;

                case 2:
                    BorrowBookFlow();
                    break;

                case 3:
                    ReturnBookFlow();
                    break;

                case 4:
                    DisplayByGenreFlow();
                    break;

                case 5:
                    shelf.DisplayEntireCatalog();
                    break;

                case 0:
                    Console.WriteLine("Exiting BookShelf...");
                    break;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }

        } while (choice != 0);
    }

    // ---------------- FLOWS ----------------

    private void AddBookFlow()
    {
        Console.Write("Enter Book ID: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Enter Title: ");
        string title = Console.ReadLine();

        Console.Write("Enter Author: ");
        string author = Console.ReadLine();

        Console.Write("Enter Genre: ");
        string genre = Console.ReadLine();

        Book book = new Book(id, title, author, genre);
        shelf.AddBookToGenre(book);
    }

    private void BorrowBookFlow()
    {
        Console.Write("Enter Genre: ");
        string genre = Console.ReadLine();

        Console.Write("Enter Book ID: ");
        int id = int.Parse(Console.ReadLine());

        shelf.BorrowBook(genre, id);
    }

    private void ReturnBookFlow()
    {
        Console.Write("Enter Book ID: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Enter Title: ");
        string title = Console.ReadLine();

        Console.Write("Enter Author: ");
        string author = Console.ReadLine();

        Console.Write("Enter Genre: ");
        string genre = Console.ReadLine();

        Book book = new Book(id, title, author, genre);
        shelf.ReturnBook(book);
    }

    private void DisplayByGenreFlow()
    {
        Console.Write("Enter Genre: ");
        string genre = Console.ReadLine();

        shelf.DisplayBooksByGenre(genre);
    }
}
