using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int> { 10, 20, 30, 40, 50 };
        int rotateBy = 2;

        List<int> rotated = RotateList(numbers, rotateBy);

        Console.WriteLine("Rotated List:");
        PrintList(rotated);
    }

    // ================= ROTATION LOGIC =================
    static List<int> RotateList(List<int> list, int k)
    {
        int n = list.Count;
        List<int> result = new List<int>();

        // Handle rotation greater than list size
        k = k % n;

        // Add elements from k to end
        for (int i = k; i < n; i++)
        {
            result.Add(list[i]);
        }

        // Add first k elements at the end
        for (int i = 0; i < k; i++)
        {
            result.Add(list[i]);
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
