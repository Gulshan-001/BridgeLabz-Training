using System;
class CustomHashMap
{
    private HashNode[] table;
    private int capacity;

    // constructor
    public CustomHashMap(int size)
    {
        capacity = size;
        table = new HashNode[capacity];
    }

    // hash function
    private int GetHash(string key)
    {
        int hash = 0;
        foreach (char ch in key)
        {
            hash += ch;
        }
        return hash % capacity;
    }

    // PUT: add or update key-value
    public void Put(string key, BookLinkedList value)
    {
        int index = GetHash(key);
        HashNode head = table[index];

        // no collision
        if (head == null)
        {
            table[index] = new HashNode(key, value);
            return;
        }

        // collision handling
        HashNode current = head;
        while (current != null)
        {
            // key already exists → update value
            if (current.Key.Equals(key))
            {
                current.Value = value;
                return;
            }

            // end of chain
            if (current.Next == null)
                break;

            current = current.Next;
        }

        // add new node at end
        current.Next = new HashNode(key, value);
    }

    // GET: return value for key
    public BookLinkedList Get(string key)
    {
        int index = GetHash(key);
        HashNode current = table[index];

        while (current != null)
        {
            if (current.Key.Equals(key))
                return current.Value;

            current = current.Next;
        }

        return null; // key not found
    }

    // CHECK if key exists
    public bool ContainsKey(string key)
    {
        return Get(key) != null;
    }

    // REMOVE key-value pair
    public void Remove(string key)
    {
        int index = GetHash(key);
        HashNode current = table[index];
        HashNode prev = null;

        while (current != null)
        {
            if (current.Key.Equals(key))
            {
                // removing head node
                if (prev == null)
                {
                    table[index] = current.Next;
                }
                else
                {
                    prev.Next = current.Next;
                }
                return;
            }

            prev = current;
            current = current.Next;
        }
    }
    public void DisplayAll()
    {
        for (int i = 0; i < capacity; i++)
        {
            HashNode current = table[i];

            while (current != null)
            {
                Console.WriteLine("\nGenre: " + current.Key);
                current.Value.DisplayBooks();
                current = current.Next;
            }
        }
    }
}
