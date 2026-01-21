using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<int> input = new List<int> { 3, 1, 2, 2, 3, 4 };

        List<int> result = RemoveDuplicates(input);

        Console.WriteLine("After removing duplicates:");
        PrintList(result);
    }

    // ================= DUPLICATE REMOVAL LOGIC =================
    static List<int> RemoveDuplicates(List<int> list)
    {
        HashSet<int> seen = new HashSet<int>();
        List<int> result = new List<int>();

        foreach (int value in list)
        {
            // Add only if this value is seen for the first time
            if (!seen.Contains(value))
            {
                seen.Add(value);
                result.Add(value);
            }
        }

        return result;
    }

    // ================= PRINT METHOD =================
    static void PrintList(List<int> list)
    {
        Console.Write("[");
        for (int i = 0; i < list.Count; i++)
        {
            Console.Write(list[i]);
            if (i < list.Count - 1)
                Console.Write(", ");
        }
        Console.WriteLine("]");
    }
}
