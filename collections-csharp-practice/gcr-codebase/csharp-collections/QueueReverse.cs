using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(10);
        queue.Enqueue(20);
        queue.Enqueue(30);

        ReverseQueue(queue);

        Console.WriteLine("Reversed Queue:");
        PrintQueue(queue);
    }

    // ================= QUEUE REVERSAL =================
    static void ReverseQueue(Queue<int> queue)
    {
        // Base case: empty queue
        if (queue.Count == 0)
            return;

        // Remove front element
        int front = queue.Dequeue();

        // Reverse remaining queue
        ReverseQueue(queue);

        // Add removed element to the back
        queue.Enqueue(front);
    }

    // ================= PRINT METHOD =================
    static void PrintQueue(Queue<int> queue)
    {
        Console.Write("[");
        bool first = true;

        foreach (int item in queue)
        {
            if (!first) Console.Write(", ");
            Console.Write(item);
            first = false;
        }

        Console.WriteLine("]");
    }
}
