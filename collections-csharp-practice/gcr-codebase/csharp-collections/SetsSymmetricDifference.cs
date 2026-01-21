using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        HashSet<int> set1 = new HashSet<int> { 1, 2, 3 };
        HashSet<int> set2 = new HashSet<int> { 3, 4, 5 };

        // Create a copy so original sets remain unchanged
        HashSet<int> symmetricDifference = new HashSet<int>(set1);

        // Keeps elements that are in one set but not both
        symmetricDifference.SymmetricExceptWith(set2);

        Console.WriteLine("Symmetric Difference:");
        PrintSet(symmetricDifference);
    }

    static void PrintSet(HashSet<int> set)
    {
        Console.Write("{ ");
        bool first = true;

        foreach (int item in set)
        {
            if (!first) Console.Write(", ");
            Console.Write(item);
            first = false;
        }

        Console.WriteLine(" }");
    }
}
