using System;
using System.Collections.Generic;

class Book
{
    public string Title;
    public string Author;

    // Book exists independently
    public Book(string title, string author)
    {
        Title = title;
        Author = author;
    }

    public void DisplayBook()
    {
        Console.WriteLine($"Title: {Title}, Author: {Author}");
    }
}

class Library
{
    public string LibraryName;
    public List<Book> Books;   // Aggregation

    public Library(string name)
    {
        LibraryName = name;
        Books = new List<Book>();
    }

    public void AddBook(Book book)
    {
        Books.Add(book);
    }

    public void DisplayLibrary()
    {
        Console.WriteLine($"\nLibrary: {LibraryName}");
        Console.WriteLine("Books available:");

        foreach (Book book in Books)
        {
            book.DisplayBook();
        }
    }
}

class Program
{
    static void Main()
    {
        // Books created independently
        Book book1 = new Book("Atomic Habits", "James Clear");
        Book book2 = new Book("Ikigai", "Hector Garcia");

        // Libraries
        Library cityLibrary = new Library("City Library");
        Library collegeLibrary = new Library("College Library");

        // Adding books to libraries
        cityLibrary.AddBook(book1);
        cityLibrary.AddBook(book2);

        collegeLibrary.AddBook(book2); // same book used again

        // Display libraries
        cityLibrary.DisplayLibrary();
        collegeLibrary.DisplayLibrary();
    }
}
