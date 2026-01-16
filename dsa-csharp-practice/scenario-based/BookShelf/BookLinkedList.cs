using System;

class BookLinkedList
{
    private BookNode head;

    // ADD BOOK TO END
    public void AddBook(Book book)
    {
        if (ContainsBook(book.BookID))
        {
            Console.WriteLine("BOOK ALREADY EXISTS");
            return;
        }

        BookNode newNode = new BookNode(book);

        if (head == null)
        {
            head = newNode;
            return;
        }

        BookNode temp = head;
        while (temp.Next != null)
        {
            temp = temp.Next;
        }
        temp.Next = newNode;
    }

    // REMOVE BOOK BY ID
    public void RemoveBook(int BookID)
    {
        if (head == null)
            return;

        // remove head
        if (head.Data.BookID == BookID)
        {
            head = head.Next;
            return;
        }

        BookNode current = head;
        while (current.Next != null)
        {
            if (current.Next.Data.BookID == BookID)
            {
                current.Next = current.Next.Next;
                return;
            }
            current = current.Next;
        }
    }

    // SEARCH BY BOOK ID
    public bool ContainsBook(int BookID)
    {
        BookNode temp = head;
        while (temp != null)
        {
            if (temp.Data.BookID == BookID)
                return true;

            temp = temp.Next;
        }
        return false;
    }

    // DISPLAY BOOKS
    public void DisplayBooks()
    {
        if (head == null)
        {
            Console.WriteLine("No books in this genre");
            return;
        }

        BookNode temp = head;
        while (temp != null)
        {
            Console.WriteLine(
                temp.Data.BookID + " | " +
                temp.Data.Title + " | " +
                temp.Data.Author
            );
            temp = temp.Next;
        }
    }
}
