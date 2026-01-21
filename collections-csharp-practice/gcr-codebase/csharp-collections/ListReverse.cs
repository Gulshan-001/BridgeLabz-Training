using System;
using System.Collections;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // -------- ArrayList Example --------
        ArrayList arrayList = new ArrayList { 1, 2, 3, 4, 5 };
        ReverseArrayList(arrayList);

        Console.WriteLine("Reversed ArrayList:");
        PrintList(arrayList);

        // -------- LinkedList Example --------
        LinkedList<int> linkedList = new LinkedList<int>();
        linkedList.AddLast(1);
        linkedList.AddLast(2);
        linkedList.AddLast(3);
        linkedList.AddLast(4);
        linkedList.AddLast(5);

        LinkedList<int> reversedLinkedList = ReverseLinkedList(linkedList);

        Console.WriteLine("\nReversed LinkedList:");
        PrintList(reversedLinkedList);
    }

    // ================= ARRAYLIST REVERSE =================
    static void ReverseArrayList(ArrayList list)
    {
        int left = 0;
        int right = list.Count - 1;

        // Swap elements from both ends
        while (left < right)
        {
            object temp = list[left];
            list[left] = list[right];
            list[right] = temp;

            left++;
            right--;
        }
    }

    // ================= LINKEDLIST REVERSE =================
    static LinkedList<int> ReverseLinkedList(LinkedList<int> list)
    {
        LinkedList<int> reversed = new LinkedList<int>();

        // Start from last node and move backwards
        var current = list.Last;

        while (current != null)
        {
            reversed.AddLast(current.Value);
            current = current.Previous;
        }

        return reversed;
    }

    // ================= PRINT METHOD =================
    static void PrintList(IEnumerable list)
    {
        Console.Write("[");
        bool first = true;

        foreach (var item in list)
        {
            if (!first) Console.Write(", ");
            Console.Write(item);
            first = false;
        }

        Console.WriteLine("]");
    }
}
