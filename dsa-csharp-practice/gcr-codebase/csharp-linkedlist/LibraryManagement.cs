using System;

// Node class
class BookNode
{
    public int BookId;
    public string Title;
    public string Author;
    public string Genre;
    public bool IsAvailable;
    public BookNode Next;
    public BookNode Prev;

    public BookNode(int id, string title, string author, string genre, bool available)
    {
        BookId = id;
        Title = title;
        Author = author;
        Genre = genre;
        IsAvailable = available;
        Next = null;
        Prev = null;
    }
}

// Doubly Linked List class
class Library
{
    private BookNode head;
    private BookNode tail;

    // Add at beginning
    public void AddAtBeginning(int id, string title, string author, string genre, bool available)
    {
        BookNode newNode = new BookNode(id, title, author, genre, available);

        if (head == null)
        {
            head = tail = newNode;
            return;
        }

        newNode.Next = head;
        head.Prev = newNode;
        head = newNode;
    }

    // Add at end
    public void AddAtEnd(int id, string title, string author, string genre, bool available)
    {
        BookNode newNode = new BookNode(id, title, author, genre, available);

        if (tail == null)
        {
            head = tail = newNode;
            return;
        }

        tail.Next = newNode;
        newNode.Prev = tail;
        tail = newNode;
    }

    // Add at specific position (1-based)
    public void AddAtPosition(int pos, int id, string title, string author, string genre, bool available)
    {
        if (pos == 1)
        {
            AddAtBeginning(id, title, author, genre, available);
            return;
        }

        BookNode temp = head;
        for (int i = 1; i < pos - 1 && temp != null; i++)
            temp = temp.Next;

        if (temp == null || temp.Next == null)
        {
            AddAtEnd(id, title, author, genre, available);
            return;
        }

        BookNode newNode = new BookNode(id, title, author, genre, available);
        newNode.Next = temp.Next;
        newNode.Prev = temp;
        temp.Next.Prev = newNode;
        temp.Next = newNode;
    }

    // Remove by Book ID
    public void RemoveById(int id)
    {
        BookNode temp = head;

        while (temp != null)
        {
            if (temp.BookId == id)
            {
                if (temp == head)
                    head = temp.Next;

                if (temp == tail)
                    tail = temp.Prev;

                if (temp.Prev != null)
                    temp.Prev.Next = temp.Next;

                if (temp.Next != null)
                    temp.Next.Prev = temp.Prev;

                Console.WriteLine("Book removed");
                return;
            }
            temp = temp.Next;
        }
        Console.WriteLine("Book not found");
    }

    // Search by Title
    public void SearchByTitle(string title)
    {
        BookNode temp = head;
        bool found = false;

        while (temp != null)
        {
            if (temp.Title.Equals(title))
            {
                PrintBook(temp);
                found = true;
            }
            temp = temp.Next;
        }

        if (!found)
            Console.WriteLine("Book not found");
    }

    // Search by Author
    public void SearchByAuthor(string author)
    {
        BookNode temp = head;
        bool found = false;

        while (temp != null)
        {
            if (temp.Author.Equals(author))
            {
                PrintBook(temp);
                found = true;
            }
            temp = temp.Next;
        }

        if (!found)
            Console.WriteLine("Book not found");
    }

    // Update availability
    public void UpdateAvailability(int id, bool status)
    {
        BookNode temp = head;

        while (temp != null)
        {
            if (temp.BookId == id)
            {
                temp.IsAvailable = status;
                Console.WriteLine("Availability updated");
                return;
            }
            temp = temp.Next;
        }
        Console.WriteLine("Book not found");
    }

    // Display forward
    public void DisplayForward()
    {
        BookNode temp = head;
        while (temp != null)
        {
            PrintBook(temp);
            temp = temp.Next;
        }
    }

    // Display reverse
    public void DisplayReverse()
    {
        BookNode temp = tail;
        while (temp != null)
        {
            PrintBook(temp);
            temp = temp.Prev;
        }
    }

    // Count books
    public void CountBooks()
    {
        int count = 0;
        BookNode temp = head;

        while (temp != null)
        {
            count++;
            temp = temp.Next;
        }

        Console.WriteLine("Total Books: " + count);
    }

    // Helper
    private void PrintBook(BookNode b)
    {
        Console.WriteLine(
            $"ID:{b.BookId}, Title:{b.Title}, Author:{b.Author}, Genre:{b.Genre}, Available:{b.IsAvailable}"
        );
    }
}

// Main
class Program
{
    static void Main()
    {
        Library lib = new Library();

        lib.AddAtEnd(1, "1984", "George Orwell", "Fiction", true);
        lib.AddAtEnd(2, "Clean Code", "Robert Martin", "Programming", true);
        lib.AddAtBeginning(3, "The Alchemist", "Paulo Coelho", "Novel", false);

        Console.WriteLine("Books (Forward):");
        lib.DisplayForward();

        Console.WriteLine("\nBooks (Reverse):");
        lib.DisplayReverse();

        Console.WriteLine("\nSearch by Author:");
        lib.SearchByAuthor("George Orwell");

        Console.WriteLine("\nUpdate Availability:");
        lib.UpdateAvailability(3, true);

        Console.WriteLine("\nRemove Book:");
        lib.RemoveById(2);

        Console.WriteLine("\nFinal Library:");
        lib.DisplayForward();

        lib.CountBooks();
    }
}