using System;

class FitnessUtility : IFitnessOperations
{
    private Runners[] runners = new Runners[10];
    private int count = 0;
    private SortOperation sorter = new SortOperation();

    public void AddRunner(Runners runner)
    {
        if (count >= 10)
        {
            Console.WriteLine("Runner storage full");
            return;
        }

        runners[count] = runner;
        count++;

        Console.WriteLine("Runner added: " + runner.Name +
                          ", Distance: " + runner.DistanceRun + " km");
    }

    public void DisplayRankings()
    {
        sorter.Sort(runners, count);

        Console.WriteLine("\n--- Daily Step Leaderboard ---");
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine(
                (i + 1) + ". " +
                runners[i].Name + " - " +
                runners[i].DistanceRun + " km"
            );
        }
    }
}
