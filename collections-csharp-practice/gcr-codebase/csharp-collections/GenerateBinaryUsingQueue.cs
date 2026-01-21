using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int N = 5;

        List<string> binaries = GenerateBinaryNumbers(N);

        Console.WriteLine("First " + N + " Binary Numbers:");
        PrintList(binaries);
    }

    // ================= BINARY GENERATION =================
    static List<string> GenerateBinaryNumbers(int n)
    {
        List<string> result = new List<string>();
        Queue<string> queue = new Queue<string>();

        // Start with first binary number
        queue.Enqueue("1");

        for (int i = 0; i < n; i++)
        {
            // Take front element
            string current = queue.Dequeue();
            result.Add(current);

            // Generate next binary numbers
            queue.Enqueue(current + "0");
            queue.Enqueue(current + "1");
        }

        return result;
    }

    // ================= PRINT METHOD =================
    static void PrintList(List<string> list)
    {
        Console.Write("{ ");
        for (int i = 0; i < list.Count; i++)
        {
            Console.Write($"\"{list[i]}\"");
            if (i < list.Count - 1)
                Console.Write(", ");
        }
        Console.WriteLine(" }");
    }
}
