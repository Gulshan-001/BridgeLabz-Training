using System;

class HashNode
{
    public int Key;
    public int Value;
    public HashNode Next;

    public HashNode(int key, int value)
    {
        Key = key;
        Value = value;
        Next = null;
    }
}

class CustomHashMap
{
    private readonly int SIZE = 10;
    private HashNode[] buckets;

    public CustomHashMap()
    {
        buckets = new HashNode[SIZE];
    }

    // Hash function
    private int GetIndex(int key)
    {
        return Math.Abs(key) % SIZE;
    }

    // Insert or Update
    public void Put(int key, int value)
    {
        int index = GetIndex(key);
        HashNode head = buckets[index];

        // Update if key exists
        while (head != null)
        {
            if (head.Key == key)
            {
                head.Value = value;
                return;
            }
            head = head.Next;
        }

        // Insert at beginning
        HashNode newNode = new HashNode(key, value);
        newNode.Next = buckets[index];
        buckets[index] = newNode;
    }

    // Get value
    public int Get(int key)
    {
        int index = GetIndex(key);
        HashNode head = buckets[index];

        while (head != null)
        {
            if (head.Key == key)
                return head.Value;

            head = head.Next;
        }

        return -1; // key not found
    }

    // Remove key
    public void Remove(int key)
    {
        int index = GetIndex(key);
        HashNode head = buckets[index];
        HashNode prev = null;

        while (head != null)
        {
            if (head.Key == key)
            {
                if (prev == null)
                    buckets[index] = head.Next;
                else
                    prev.Next = head.Next;

                return;
            }
            prev = head;
            head = head.Next;
        }
    }

    // Check key existence
    public bool ContainsKey(int key)
    {
        return Get(key) != -1;
    }
}

class Program
{
    static void Main()
    {
        CustomHashMap map = new CustomHashMap();

        map.Put(1, 100);
        map.Put(11, 200); // collision
        map.Put(2, 300);

        Console.WriteLine(map.Get(1));   // 100
        Console.WriteLine(map.Get(11));  // 200

        map.Remove(1);
        Console.WriteLine(map.Get(1));   // -1
    }
}
