using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        HashSet<int> set1 = new HashSet<int> { 1, 2, 3 };
        HashSet<int> set2 = new HashSet<int> { 3, 4, 5 };

        // UNION
        HashSet<int> union = new HashSet<int>(set1);
        union.UnionWith(set2);

        // INTERSECTION
        HashSet<int> intersection = new HashSet<int>(set1);
        intersection.IntersectWith(set2);

        Console.WriteLine("Union:");
        PrintSet(union);

        Console.WriteLine("Intersection:");
        PrintSet(intersection);
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
