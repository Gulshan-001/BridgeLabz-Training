using System;

class Program
{
    static void Main()
    {
        IFitnessOperations fitness = new FitnessUtility();

        Console.Write("Enter number of runners: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("\nEnter details for Runner " + (i + 1));

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Distance Run (steps/km): ");
            int distance = int.Parse(Console.ReadLine());

            fitness.AddRunner(new Runners(name, distance));
        }

        // sort + display
        fitness.DisplayRankings();
    }
}
