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
        // 3D Array: [10 books, 3 fields, 1 value]
        string[,] books = new string[10, 3];

        // Book 1
        books[0, 0] = "Atomic Habits";
        books[0, 1] = "James Clear";
        books[0, 2] = "true";

        // Book 2
        books[1, 0] = "1984";
        books[1, 1] = "George Orwell";
        books[1, 2] = "false";

        // Book 3
        books[2, 0] = "The Alchemist";
        books[2, 1] = "Paulo Coelho";
        books[2, 2] = "true";

        // Book 4
        books[3, 0] = "Rich Dad Poor Dad";
        books[3, 1] = "Robert Kiyosaki";
        books[3, 2] = "false";

        // Book 5
        books[4, 0] = "Think and Grow Rich";
        books[4, 1] = "Napoleon Hill";
        books[4, 2] = "true";

        // Book 6
        books[5, 0] = "Clean Code";
        books[5, 1] = "Robert C. Martin";
        books[5, 2] = "false";

        // Book 7
        books[6, 0] = "The Hobbit";
        books[6, 1] = "J.R.R. Tolkien";
        books[6, 2] = "true";

        // Book 8
        books[7, 0] = "The Psychology of Money";
        books[7, 1] = "Morgan Housel";
        books[7, 2] = "false";

        // Book 9
        books[8, 0] = "Harry Potter";
        books[8, 1] = "J.K. Rowling";
        books[8, 2] = "true";

        // Book 10
        books[9, 0] = "Ikigai";
        books[9, 1] = "Hector Garcia";
        books[9, 2] = "false";

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
