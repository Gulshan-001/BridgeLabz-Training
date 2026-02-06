using System;
namespace LibraryManagement
{
    public class Menu
    {
         private ILibrary libraryUtility;

        public Menu(Ilibray utility)
        {
            libraryUtility = utility;
        }
        public void ShowMenu()
        {
            Console.WriteLine("Library Management System Menu:");
            Console.WriteLine("1. Display Library Books");
            Console.WriteLine("2. Search Book by Title");
            Console.WriteLine("3. Update Book Status");
            Console.WriteLine("4. Exit");
            Console.WriteLine("Select an option (1-4):");
            int choice=Console.ReadLine();
            switch (choice)
                {
                    case 1:
                        libraryUtility.displayLib();
                        break;
                    case 2:
                        libraryUtility.searchBook();
                        break;
                    case 3:
                        libraryUtility.updateBookStatus();
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Invalid choice\n");
                        break;
                }
        }
        
    }
}