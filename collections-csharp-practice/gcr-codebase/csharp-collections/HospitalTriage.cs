using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // PriorityQueue where lower priority value is served first
        PriorityQueue<string, int> triageQueue = new PriorityQueue<string, int>();

        // Add patients (use negative severity)
        triageQueue.Enqueue("John", -3);
        triageQueue.Enqueue("Alice", -5);
        triageQueue.Enqueue("Bob", -2);

        Console.WriteLine("Treatment Order:");

        while (triageQueue.Count > 0)
        {
            string patient = triageQueue.Dequeue();
            Console.WriteLine(patient);
        }
    }
}
