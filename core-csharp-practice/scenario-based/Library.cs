using System;
using System.Transactions;

class Library

{
    static string changeBookStatus(string t,string[,] lib)
    {
        for (int i = 0; i < lib.GetLength(0); i++)
        {
            if (string.Equals(lib[i, 0], t, StringComparison.OrdinalIgnoreCase))
            {
                if (lib[i, 2] == "true")
                {
                    lib[i,2]="false";
                    return"Status Changed successfully. Now:Issued";
                }
                else
                {
                    lib[i,2]="true";
                    return"Status Changed successfully. Now:Available";

                }
            }
        }
        return"Book Not Available";
    }
    static string searchBook(string nameb, string[,] lib)
    {
    for (int i = 0; i < lib.GetLength(0); i++)
    {
        
        if (lib[i, 0]
            .IndexOf(nameb, StringComparison.OrdinalIgnoreCase) >= 0)
        {
            if (lib[i, 2] == "true")
            {
                return $"Book Found: {lib[i, 0]} (Available)";
            }
            else
            {
                return $"Book Found: {lib[i, 0]} (Already Issued)";
            }
        }
    }

    return "No matching book found";
    }


    static void Main()
    {
        string[,] books =
{
    { "Atomic Habits", "James Clear", "true" },
    { "1984", "George Orwell", "false" },
    { "The Alchemist", "Paulo Coelho", "true" },
    { "Rich Dad Poor Dad", "Robert Kiyosaki", "false" },
    { "Think and Grow Rich", "Napoleon Hill", "true" },
    { "Clean Code", "Robert C. Martin", "false" },
    { "The Hobbit", "J.R.R. Tolkien", "true" },
    { "The Psychology of Money", "Morgan Housel", "false" },
    { "Harry Potter", "J.K. Rowling", "true" },
    { "Ikigai", "Hector Garcia", "false" }
};

        Console.WriteLine("SELECT YOUR ROLE:-");
        Console.WriteLine("1- ADMIN");
        Console.WriteLine("2-USER");
        string role=Console.ReadLine();

        if (role == "2")
        {
            Console.WriteLine("Enter Title Of The Book You Want to Search:");
            string tempTitle = Console.ReadLine();
            Console.WriteLine(searchBook(tempTitle,books));
        }
        else if(role=="1")
        {
            Console.WriteLine("Enter the Title of the book whose status you wanna change:");
            string tempTitle2 = Console.ReadLine();
            Console.WriteLine(changeBookStatus(tempTitle2,books));
            
        }
    }
}
