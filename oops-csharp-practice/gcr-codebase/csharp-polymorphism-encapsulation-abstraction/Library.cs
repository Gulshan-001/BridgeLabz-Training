using System;
using System.Collections.Generic;

// Interface for reserving items
interface IReservable
{
    void ReserveItem();
    bool CheckAvailability();
}

// Abstract class
abstract class LibraryItem
{
    protected int itemId;
    protected string title;
    protected string author;

    // encapsulated borrower info
    private string borrowerName;
    private bool isAvailable = true;

    public LibraryItem(int id, string title, string author)
    {
        this.itemId = id;
        this.title = title;
        this.author = author;
    }

    // abstract method
    public abstract int GetLoanDuration();

    // common method
    public void GetItemDetails()
    {
        Console.WriteLine("Item ID: " + itemId);
        Console.WriteLine("Title: " + title);
        Console.WriteLine("Author: " + author);
        Console.WriteLine("Loan Days: " + GetLoanDuration());
        Console.WriteLine("Available: " + isAvailable);
        Console.WriteLine("---------------------");
    }

    // protected helpers
    protected void Borrow(string name)
    {
        borrowerName = name;
        isAvailable = false;
    }

    protected void MakeAvailable()
    {
        borrowerName = "";
        isAvailable = true;
    }

    protected bool IsAvailable()
    {
        return isAvailable;
    }
}

// Book class
class Book : LibraryItem, IReservable
{
    public Book(int id, string title, string author)
        : base(id, title, author) { }

    public override int GetLoanDuration()
    {
        return 14; // 14 days
    }

    public void ReserveItem()
    {
        if (IsAvailable())
        {
            Borrow("Student");
            Console.WriteLine("Book reserved");
        }
    }

    public bool CheckAvailability()
    {
        return IsAvailable();
    }
}

// Magazine class
class Magazine : LibraryItem, IReservable
{
    public Magazine(int id, string title, string author)
        : base(id, title, author) { }

    public override int GetLoanDuration()
    {
        return 7; // 7 days
    }

    public void ReserveItem()
    {
        if (IsAvailable())
        {
            Borrow("Reader");
            Console.WriteLine("Magazine reserved");
        }
    }

    public bool CheckAvailability()
    {
        return IsAvailable();
    }
}

// DVD class
class DVD : LibraryItem, IReservable
{
    public DVD(int id, string title, string author)
        : base(id, title, author) { }

    public override int GetLoanDuration()
    {
        return 3; // 3 days
    }

    public void ReserveItem()
    {
        if (IsAvailable())
        {
            Borrow("Member");
            Console.WriteLine("DVD reserved");
        }
    }

    public bool CheckAvailability()
    {
        return IsAvailable();
    }
}

class Program
{
    static void Main()
    {
        List<LibraryItem> items = new List<LibraryItem>();

        items.Add(new Book(1, "Atomic Habits", "James Clear"));
        items.Add(new Magazine(2, "Time", "Editorial"));
        items.Add(new DVD(3, "Inception", "Nolan"));

        // polymorphism
        foreach (LibraryItem item in items)
        {
            item.GetItemDetails();
        }
    }
}
