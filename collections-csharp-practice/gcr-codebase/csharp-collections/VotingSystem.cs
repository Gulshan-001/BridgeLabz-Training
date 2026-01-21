using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Stores vote count (fast lookup)
        Dictionary<string, int> voteCount = new Dictionary<string, int>();

        // Maintains order in which votes were cast (LinkedHashMap behavior)
        List<string> voteOrder = new List<string>();

        // Cast votes
        CastVote("Alice");
        CastVote("Bob");
        CastVote("Alice");
        CastVote("Charlie");
        CastVote("Bob");
        CastVote("Alice");

        Console.WriteLine("\nVotes in Casting Order:");
        DisplayVoteOrder();

        Console.WriteLine("\nFinal Vote Count:");
        DisplayVoteCount();

        Console.WriteLine("\nSorted Results (Alphabetical):");
        DisplaySortedResults();

        // ---------- LOCAL FUNCTIONS ----------

        void CastVote(string candidate)
        {
            // Record vote order
            voteOrder.Add(candidate);

            // Update vote count
            if (voteCount.ContainsKey(candidate))
                voteCount[candidate]++;
            else
                voteCount[candidate] = 1;
        }

        void DisplayVoteOrder()
        {
            foreach (var name in voteOrder)
                Console.WriteLine(name);
        }

        void DisplayVoteCount()
        {
            foreach (var pair in voteCount)
                Console.WriteLine($"{pair.Key} → {pair.Value} votes");
        }

        void DisplaySortedResults()
        {
            // SortedDictionary keeps keys in sorted order
            SortedDictionary<string, int> sorted =
                new SortedDictionary<string, int>(voteCount);

            foreach (var pair in sorted)
                Console.WriteLine($"{pair.Key} → {pair.Value} votes");
        }
    }
}
