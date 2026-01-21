using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        HashSet<int> setA = new HashSet<int> { 2, 3 };
        HashSet<int> setB = new HashSet<int> { 1, 2, 3, 4 };

        bool isSubset = IsSubset(setA, setB);

        Console.WriteLine(isSubset);
    }

    // ================= SUBSET CHECK =================
    static bool IsSubset(HashSet<int> subset, HashSet<int> superset)
    {
        return subset.IsSubsetOf(superset);
    }
}
