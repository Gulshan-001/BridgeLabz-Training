using System;

class BookShelfUtilityImpl : IBookShelfOperations
{
    private CustomHashMap genreMap;

    public BookShelfUtilityImpl()
    {
        // custom hashmap with fixed size
        genreMap = new CustomHashMap(10);
    }

    // ADD BOOK TO A GENRE
    public void AddBookToGenre(Book book)
    {
        string genre = book.Genre;

        // get linked list for genre
        BookLinkedList list = genreMap.Get(genre);

        // if genre does not exist, create it
        if (list == null)
        {
            list = new BookLinkedList();
            genreMap.Put(genre, list);
        }

        list.AddBook(book);
        Console.WriteLine("Book added to genre: " + genre);
    }

    // BORROW BOOK (REMOVE FROM GENRE)
    public void BorrowBook(string genre, int bookId)
    {
        BookLinkedList list = genreMap.Get(genre);

        if (list == null)
        {
            Console.WriteLine("Genre not found");
            return;
        }

        if (!list.ContainsBook(bookId))
        {
            Console.WriteLine("Book not found");
            return;
        }

        list.RemoveBook(bookId);
        Console.WriteLine("Book borrowed successfully");
    }

    // RETURN BOOK (ADD BACK)
    public void ReturnBook(Book book)
    {
        string genre = book.Genre;

        BookLinkedList list = genreMap.Get(genre);

        if (list == null)
        {
            list = new BookLinkedList();
            genreMap.Put(genre, list);
        }

        list.AddBook(book);
        Console.WriteLine("Book returned successfully");
    }

    // DISPLAY BOOKS BY GENRE
    public void DisplayBooksByGenre(string genre)
    {
        BookLinkedList list = genreMap.Get(genre);

        if (list == null)
        {
            Console.WriteLine("No books found for genre: " + genre);
            return;
        }

        Console.WriteLine("Books in genre: " + genre);
        list.DisplayBooks();
    }

    // DISPLAY ALL BOOKS (ALL GENRES)
    public void DisplayEntireCatalog()
    {
        Console.WriteLine("Displaying entire catalog:");

        genreMap.DisplayAll();   // this method will loop through all buckets
    }
}
