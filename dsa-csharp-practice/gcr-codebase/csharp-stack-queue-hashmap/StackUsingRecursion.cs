using System;
using System.Collections.Generic;

class StackUsingRecursion
{
    // Sort the stack
    static void SortStack(Stack<int> stack)
    {
        if (stack.Count == 0)
            return;

        int top = stack.Pop();

        SortStack(stack);

        InsertSorted(stack, top);
    }

    // Insert element in sorted order
    static void InsertSorted(Stack<int> stack, int value)
    {
        if (stack.Count == 0 || value >= stack.Peek())
        {
            stack.Push(value);
            return;
        }

        int temp = stack.Pop();
        InsertSorted(stack, value);
        stack.Push(temp);
    }

    static void Main()
    {
        Stack<int> stack = new Stack<int>();

        stack.Push(30);
        stack.Push(10);
        stack.Push(20);
        stack.Push(5);

        Console.WriteLine("Original Stack:");
        PrintStack(stack);

        SortStack(stack);

        Console.WriteLine("\nSorted Stack (Ascending):");
        PrintStack(stack);
    }

    static void PrintStack(Stack<int> stack)
    {
        foreach (int item in stack)
            Console.Write(item + " ");
    }
}
