using System;

public class SinglyLinkedList
{
    private Node head;

    public void AddLast(string data)
    {
        Node newNode = new Node(data);

        if (head == null)
        {
            head = newNode;
            return;
        }

        Node temp = head;
        while (temp.Next != null)
        {
            temp = temp.Next;
        }
        temp.Next = newNode;
    }

    public bool InsertAfter(string existingData, string newData)
    {
        Node temp = head;

        while (temp != null)
        {
            if (temp.Data.Equals(existingData))
            {
                Node newNode = new Node(newData);
                newNode.Next = temp.Next;
                temp.Next = newNode;
                return true;
            }
            temp = temp.Next;
        }
        return false;
    }

    public bool Remove(string data)
    {
        if (head == null)
            return false;

        if (head.Data.Equals(data))
        {
            head = head.Next;
            return true;
        }

        Node prev = head;
        Node curr = head.Next;

        while (curr != null)
        {
            if (curr.Data.Equals(data))
            {
                prev.Next = curr.Next;
                return true;
            }
            prev = curr;
            curr = curr.Next;
        }
        return false;
    }

    public void Display()
    {
        if (head == null)
        {
            Console.WriteLine("No parcel stages available.");
            return;
        }

        Node temp = head;
        while (temp != null)
        {
            Console.Write(temp.Data);
            if (temp.Next != null)
                Console.Write(" -> ");
            temp = temp.Next;
        }
        Console.WriteLine();
    }
}
