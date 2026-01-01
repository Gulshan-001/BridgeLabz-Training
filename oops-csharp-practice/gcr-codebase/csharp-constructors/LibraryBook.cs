using System;

class LibraryBook
{
    string title;
    string author;
    double price;
    bool isAvailable;

    public LibraryBook(string t, string a, double p)
    {
        title = t;
        author = a;
        price = p;
        isAvailable = true;
    }

    public void BorrowBook()
    {
        // If the book is already borrowed, don't allow again
        if (!isAvailable)
        {
            Console.WriteLine("Sorry, this book is already borrowed.");
        }
        else
        {
            isAvailable = false;
            Console.WriteLine("You have successfully borrowed the book.");
        }
    }

    public void DisplayBook()
    {
        Console.WriteLine("Title: " + title);
        Console.WriteLine("Author: " + author);
        Console.WriteLine("Price: " + price);
        Console.WriteLine("Available: " + (isAvailable ? "Yes" : "No"));
    }
}

class Program
{
    static void Main()
    {
        LibraryBook book = new LibraryBook("Clean Code", "Robert C. Martin", 550);

        book.DisplayBook();
        Console.WriteLine();

        // First borrow attempt
        book.BorrowBook();
        Console.WriteLine();

        // Second borrow attempt
        book.BorrowBook();
        Console.WriteLine();

        book.DisplayBook();
    }
}
