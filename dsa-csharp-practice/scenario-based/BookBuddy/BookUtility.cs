using System;

class BookUtility : IBookOperations
{
    private string[] books = new string[50]; // fixed size
    private int count = 0;

    public void AddBook(string title, string author)
    {
        books[count] = title + " - " + author;
        count++;
        Console.WriteLine("Book added");
    }

    public void SortBooksAlphabetically()
    {
        for (int i = 0; i < count - 1; i++)
        {
            for (int j = i + 1; j < count; j++)
            {
                if (string.Compare(books[i], books[j]) > 0)
                {
                    string temp = books[i];
                    books[i] = books[j];
                    books[j] = temp;
                }
            }
        }

        Console.WriteLine("Books sorted alphabetically");
    }

    public void SearchbyAuthor(string author)
    {
        bool found = false;

        for (int i = 0; i < count; i++)
        {
            string[] parts = books[i].Split('-');
            string bookAuthor = parts[1].Trim();

            if (bookAuthor.Contains(author))
            {
                Console.WriteLine(books[i]);
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("No books found for this author");
        }
    }

    public void DisplayAllBooks()
    {
        if (count == 0)
        {
            Console.WriteLine("No books available");
            return;
        }

        for (int i = 0; i < count; i++)
        {
            Console.WriteLine(books[i]);
        }
    }
}
