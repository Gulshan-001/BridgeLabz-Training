using System;

class MovieMenu
{
    private MovieUtility utility = new MovieUtility();

    public void Start()
    {
        while (true)
        {
            Console.WriteLine("\n--- CinemaTime Menu ---");
            Console.WriteLine("1. Add Movie");
            Console.WriteLine("2. Search Movie");
            Console.WriteLine("3. Display All Movies");
            Console.WriteLine("4. Print Report");
            Console.WriteLine("5. Exit");
            Console.Write("Enter choice: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter movie title: ");
                    string title = Console.ReadLine();

                    Console.Write("Enter show time: ");
                    string time = Console.ReadLine();

                    utility.AddMovie(title, time);
                    break;

                case 2:
                    Console.Write("Enter keyword: ");
                    string keyword = Console.ReadLine();
                    utility.SearchMovie(keyword);
                    break;

                case 3:
                    utility.DisplayAllMovies();
                    break;

                case 4:
                    utility.PrintReport();
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
