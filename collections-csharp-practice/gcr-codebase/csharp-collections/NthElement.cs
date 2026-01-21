using System;

class Program
{
    static void Main()
    {
        // Create linked list: A -> B -> C -> D -> E
        Node head = new Node("A");
        head.Next = new Node("B");
        head.Next.Next = new Node("C");
        head.Next.Next.Next = new Node("D");
        head.Next.Next.Next.Next = new Node("E");

        int N = 2;

        string result = FindNthFromEnd(head, N);

        Console.WriteLine($"Nth element from end: {result}");
    }

    // ================= FIND NTH FROM END =================
    static string FindNthFromEnd(Node head, int n)
    {
        Node fast = head;
        Node slow = head;

        // Move fast pointer n steps ahead
        for (int i = 0; i < n; i++)
        {
            if (fast == null)
                return "N is larger than list length";

            fast = fast.Next;
        }

        // Move both pointers until fast reaches end
        while (fast != null)
        {
            fast = fast.Next;
            slow = slow.Next;
        }

        return slow.Data;
    }
}

// ================= NODE CLASS =================
class Node
{
    public string Data;
    public Node Next;

    public Node(string data)
    {
        Data = data;
        Next = null;
    }
}
