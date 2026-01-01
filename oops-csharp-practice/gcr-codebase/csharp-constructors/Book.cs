using System;

class Book
{
    string title;
    string author;
    double price;

    // Default constructor
    public Book()
    {
        title = "Unknown";
        author = "Unknown";
        price = 0.0;
    }

    // Parameterized constructor
    public Book(string t, string a, double p)
    {
        title = t;
        author = a;
        price = p;
    }

    public void DisplayBook()
    {
        Console.WriteLine("Title: " + title);
        Console.WriteLine("Author: " + author);
        Console.WriteLine("Price: " + price);
    }
}

class Program
{
    static void Main()
    {
        // Using default constructor
        Book book1 = new Book();
        Console.WriteLine("Default Book Details:");
        book1.DisplayBook();

        Console.WriteLine();

        // Using parameterized constructor
        Book book2 = new Book("Atomic Habits", "James Clear", 450);
        Console.WriteLine("Parameterized Book Details:");
        book2.DisplayBook();
    }
}
