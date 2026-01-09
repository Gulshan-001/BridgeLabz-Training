using System;
using System.Collections.Generic;

class QueueUsingStack
{
    Stack<int> stackEnqueue = new Stack<int>();
    Stack<int> stackDequeue = new Stack<int>();

    // Enqueue operation
    public void Enqueue(int value)
    {
        stackEnqueue.Push(value);
        Console.WriteLine(value + " enqueued");
    }

    // Dequeue operation
    public void Dequeue()
    {
        if (stackEnqueue.Count == 0 && stackDequeue.Count == 0)
        {
            Console.WriteLine("Queue is empty");
            return;
        }

        if (stackDequeue.Count == 0)
        {
            while (stackEnqueue.Count > 0)
            {
                stackDequeue.Push(stackEnqueue.Pop());
            }
        }

        int removed = stackDequeue.Pop();
        Console.WriteLine(removed + " dequeued");
    }
}

class Program
{
    static void Main()
    {
        QueueUsingStacks queue = new QueueUsingStacks();

        queue.Enqueue(10);
        queue.Enqueue(20);
        queue.Enqueue(30);

        queue.Dequeue();
        queue.Dequeue();

        queue.Enqueue(40);

        queue.Dequeue();
        queue.Dequeue();
        queue.Dequeue();
    }
}
