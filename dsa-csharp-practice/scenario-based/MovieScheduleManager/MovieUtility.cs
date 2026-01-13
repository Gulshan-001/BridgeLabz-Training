using System;

class MovieUtility : IMovieOperations
{
    private string[] titles = new string[10];
    private string[] times = new string[10];
    private int count = 0;

    public void AddMovie(string title, string time)
    {
        if (count >= 10)
        {
            Console.WriteLine("Movie storage full");
            return;
        }

        titles[count] = title;
        times[count] = time;
        count++;

        Console.WriteLine("Movie added");
    }

    public void SearchMovie(string keyword)
    {
        bool found = false;

        for (int i = 0; i < count; i++)
        {
            if (titles[i].Contains(keyword))
            {
                Console.WriteLine(titles[i] + " at " + times[i]);
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("Movie not found");
        }
    }

    public void DisplayAllMovies()
    {
        if (count == 0)
        {
            Console.WriteLine("No movies available");
            return;
        }

        for (int i = 0; i < count; i++)
        {
            Console.WriteLine(titles[i] + " at " + times[i]);
        }
    }

    // Array already just printing
    public void PrintReport()
    {
        Console.WriteLine("\nMovie Report:");
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine(titles[i]);
        }
    }
}
