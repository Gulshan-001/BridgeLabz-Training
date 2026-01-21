using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        HashSet<int> set = new HashSet<int> { 5, 3, 9, 1 };

        List<int> sortedList = ConvertToSortedList(set);

        Console.WriteLine("Sorted List:");
        PrintList(sortedList);
    }

    // ================= CONVERSION + SORT =================
    static List<int> ConvertToSortedList(HashSet<int> set)
    {
        List<int> list = new List<int>(set);
        list.Sort(); // Ascending order
        return list;
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
