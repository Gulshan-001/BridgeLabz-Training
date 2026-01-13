using System;

class BookMenu
{
    private BookUtility utility = new BookUtility();

    public void Start()
    {
        while (true)
        {
            Console.WriteLine("\n--- BookBuddy Menu ---");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Sort Books");
            Console.WriteLine("3. Search by Author");
            Console.WriteLine("4. Display All Books");
            Console.WriteLine("5. Exit");
            Console.Write("Enter choice: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter title: ");
                    string title = Console.ReadLine();

                    Console.Write("Enter author: ");
                    string author = Console.ReadLine();

                    utility.AddBook(title, author);
                    break;

                case 2:
                    utility.SortBooksAlphabetically();
                    break;

                case 3:
                    Console.Write("Enter author name: ");
                    string searchAuthor = Console.ReadLine();
                    utility.SearchbyAuthor(searchAuthor);
                    break;

                case 4:
                    utility.DisplayAllBooks();
                    break;

                case 5:
                    return;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
}
