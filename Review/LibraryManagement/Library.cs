using System;
namespace LibraryManagement
{
    class Library
    {
         private Book[] books;
         public Library(Book[] initialBooks)
        {
            books=initialBooks;
        }
        public void displayLib()
        {
            Console.WriteLine("Library Books:");
            foreach(var book in books)
            {
                Console.WriteLine($"Title:{book.Title}, Author:{book.Author}, Available:{book.isAvailable}");

            }
        }
         public static void SearchBook(string keyword)
    {
        Console.WriteLine("\nSearch Results:");
        foreach (Book b in Data.Books)
        {
            if (b.Title.ToLower().Contains(keyword.ToLower()))
            {
                Console.WriteLine($"{b.Title} - {(b.IsAvailable ? "Available" : "Checked Out")}");
            }
        }
    }
        public static void updateBookStatus(string title)
    {
        foreach (Book b in Data.Books)
        {
            if (b.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
            {
                if (b.IsAvailable)
                {
                    b.IsAvailable = false;
                    Console.WriteLine("Book checked out successfully.");
                }
                else
                {
                    Console.WriteLine("Book already checked out.");
                }
                return;
            }
        }
        Console.WriteLine("Book not found.");
    }
}

    }

