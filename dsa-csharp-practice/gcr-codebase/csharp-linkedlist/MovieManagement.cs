using System;

// Node class
class MovieNode
{
    public string Title;
    public string Director;
    public int Year;
    public double Rating;

    public MovieNode Next;
    public MovieNode Prev;

    public MovieNode(string title, string director, int year, double rating)
    {
        Title = title;
        Director = director;
        Year = year;
        Rating = rating;
        Next = null;
        Prev = null;
    }
}

// Doubly Linked List
class MovieDoublyLinkedList
{
    private MovieNode head;
    private MovieNode tail;

    // add at beginning
    public void AddAtBeginning(string title, string director, int year, double rating)
    {
        MovieNode newNode = new MovieNode(title, director, year, rating);

        if (head == null)
        {
            head = tail = newNode;
            return;
        }

        newNode.Next = head;
        head.Prev = newNode;
        head = newNode;
    }

    // add at end
    public void AddAtEnd(string title, string director, int year, double rating)
    {
        MovieNode newNode = new MovieNode(title, director, year, rating);

        if (tail == null)
        {
            head = tail = newNode;
            return;
        }

        tail.Next = newNode;
        newNode.Prev = tail;
        tail = newNode;
    }

    // add at position (1-based)
    public void AddAtPosition(int position, string title, string director, int year, double rating)
    {
        if (position == 1)
        {
            AddAtBeginning(title, director, year, rating);
            return;
        }

        MovieNode temp = head;
        for (int i = 1; i < position - 1 && temp != null; i++)
        {
            temp = temp.Next;
        }

        if (temp == null)
        {
            Console.WriteLine("Invalid position");
            return;
        }

        MovieNode newNode = new MovieNode(title, director, year, rating);
        newNode.Next = temp.Next;
        newNode.Prev = temp;

        if (temp.Next != null)
            temp.Next.Prev = newNode;
        else
            tail = newNode;

        temp.Next = newNode;
    }

    // remove by movie title
    public void RemoveByTitle(string title)
    {
        MovieNode temp = head;

        while (temp != null)
        {
            if (temp.Title == title)
            {
                if (temp.Prev != null)
                    temp.Prev.Next = temp.Next;
                else
                    head = temp.Next;

                if (temp.Next != null)
                    temp.Next.Prev = temp.Prev;
                else
                    tail = temp.Prev;

                Console.WriteLine("Movie removed");
                return;
            }
            temp = temp.Next;
        }

        Console.WriteLine("Movie not found");
    }

    // search by director
    public void SearchByDirector(string director)
    {
        MovieNode temp = head;
        bool found = false;

        while (temp != null)
        {
            if (temp.Director == director)
            {
                PrintMovie(temp);
                found = true;
            }
            temp = temp.Next;
        }

        if (!found)
            Console.WriteLine("No movies found for this director");
    }

    // search by rating
    public void SearchByRating(double rating)
    {
        MovieNode temp = head;
        bool found = false;

        while (temp != null)
        {
            if (temp.Rating >= rating)
            {
                PrintMovie(temp);
                found = true;
            }
            temp = temp.Next;
        }

        if (!found)
            Console.WriteLine("No movies found with this rating");
    }

    // update rating
    public void UpdateRating(string title, double newRating)
    {
        MovieNode temp = head;

        while (temp != null)
        {
            if (temp.Title == title)
            {
                temp.Rating = newRating;
                Console.WriteLine("Rating updated");
                return;
            }
            temp = temp.Next;
        }

        Console.WriteLine("Movie not found");
    }

    // display forward
    public void DisplayForward()
    {
        MovieNode temp = head;

        if (temp == null)
        {
            Console.WriteLine("No movie records");
            return;
        }

        while (temp != null)
        {
            PrintMovie(temp);
            temp = temp.Next;
        }
    }

    // display reverse
    public void DisplayReverse()
    {
        MovieNode temp = tail;

        if (temp == null)
        {
            Console.WriteLine("No movie records");
            return;
        }

        while (temp != null)
        {
            PrintMovie(temp);
            temp = temp.Prev;
        }
    }

    // helper method
    private void PrintMovie(MovieNode m)
    {
        Console.WriteLine($"Title: {m.Title}, Director: {m.Director}, Year: {m.Year}, Rating: {m.Rating}");
    }
}

// main program
class Program
{
    static void Main()
    {
        MovieDoublyLinkedList list = new MovieDoublyLinkedList();

        list.AddAtBeginning("Inception", "Nolan", 2010, 9.0);
        list.AddAtEnd("Interstellar", "Nolan", 2014, 8.8);
        list.AddAtEnd("Avatar", "Cameron", 2009, 7.8);

        Console.WriteLine("\nAll Movies (Forward):");
        list.DisplayForward();

        Console.WriteLine("\nAll Movies (Reverse):");
        list.DisplayReverse();

        Console.WriteLine("\nSearch by Director (Nolan):");
        list.SearchByDirector("Nolan");

        Console.WriteLine("\nUpdate Rating of Avatar:");
        list.UpdateRating("Avatar", 8.2);

        Console.WriteLine("\nAfter Update:");
        list.DisplayForward();

        Console.WriteLine("\nRemove Movie: Inception");
        list.RemoveByTitle("Inception");

        Console.WriteLine("\nFinal List:");
        list.DisplayForward();
    }
}
