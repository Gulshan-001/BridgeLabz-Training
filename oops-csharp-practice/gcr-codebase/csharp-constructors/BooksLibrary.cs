using System;

class BooksLibrary
{
    public string ISBN;
    protected string title;
    private string author;

    public BooksLibrary(string isbn, string bookTitle, string bookAuthor)
    {
        ISBN = isbn;
        title = bookTitle;
        author = bookAuthor;
    }

    public void SetAuthor(string newAuthor)
    {
        // Author is private, so it can be updated only through this method
        author = newAuthor;
    }

    public string GetAuthor()
    {
        // Controlled access to private author
        return author;
    }
}

class EBook : BooksLibrary
{
    double fileSize;

    public EBook(string isbn, string bookTitle, string bookAuthor, double size)
        : base(isbn, bookTitle, bookAuthor)
    {
        fileSize = size;
    }

    public void DisplayEBook()
    {
        Console.WriteLine("ISBN: " + ISBN);
        Console.WriteLine("Title: " + title);
        Console.WriteLine("Author: " + GetAuthor());
        Console.WriteLine("File Size (MB): " + fileSize);
    }
}

class Program
{
    static void Main()
    {
        EBook ebook = new EBook("978-0132350884", "Clean Code", "Robert C. Martin", 5.2);

        ebook.DisplayEBook();

        Console.WriteLine();

        // Updating author using public method
        ebook.SetAuthor("Uncle Bob");
        Console.WriteLine("After Author Update:");
        ebook.DisplayEBook();
    }
}
