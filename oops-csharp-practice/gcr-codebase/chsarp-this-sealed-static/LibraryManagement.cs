using System;

class LibraryManagement
{
    // Static variable shared by all books
    public static string LibraryName = "City Central Library";

    public string Title;
    public string Author;
    public readonly string ISBN;

    public LibraryManagement(string title, string author, string isbn)
    {
        // Using this to assign values to the current object
        this.Title = title;
        this.Author = author;
        this.ISBN = isbn;
    }

    public void DisplayBookDetails()
    {
        Console.WriteLine("Library: " + LibraryName);
        Console.WriteLine("Title: " + Title);
        Console.WriteLine("Author: " + Author);
        Console.WriteLine("ISBN: " + ISBN);
    }

    public static void DisplayLibraryName()
    {
        Console.WriteLine("Library Name: " + LibraryName);
    }
}

class Program
{
    static void Main()
    {
        LibraryManagement book1 = new LibraryManagement("Clean Code", "Robert C. Martin", "978-0132350884");
        LibraryManagement book2 = new LibraryManagement("Atomic Habits", "James Clear", "978-0735211292");

        // Display shared library name
        LibraryManagement.DisplayLibraryName();
        Console.WriteLine();

        // Using is operator before displaying details
        if (book1 is LibraryManagement )
        {
            book1.DisplayBookDetails();
        }

        Console.WriteLine();

        if (book2 is Book)
        {
            book2.DisplayBookDetails();
        }
    }
}