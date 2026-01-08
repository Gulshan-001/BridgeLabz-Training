using System;

// Node class
class ItemNode
{
    public int ItemId;
    public string ItemName;
    public int Quantity;
    public double Price;
    public ItemNode Next;

    public ItemNode(int id, string name, int qty, double price)
    {
        ItemId = id;
        ItemName = name;
        Quantity = qty;
        Price = price;
        Next = null;
    }
}

// Linked List class
class Inventory
{
    private ItemNode head;

    // Add at beginning
    public void AddAtBeginning(int id, string name, int qty, double price)
    {
        ItemNode newNode = new ItemNode(id, name, qty, price);
        newNode.Next = head;
        head = newNode;
    }

    // Add at end
    public void AddAtEnd(int id, string name, int qty, double price)
    {
        ItemNode newNode = new ItemNode(id, name, qty, price);

        if (head == null)
        {
            head = newNode;
            return;
        }

        ItemNode temp = head;
        while (temp.Next != null)
            temp = temp.Next;

        temp.Next = newNode;
    }

    // Add at specific position (1-based)
    public void AddAtPosition(int pos, int id, string name, int qty, double price)
    {
        if (pos == 1)
        {
            AddAtBeginning(id, name, qty, price);
            return;
        }

        ItemNode temp = head;
        for (int i = 1; i < pos - 1 && temp != null; i++)
            temp = temp.Next;

        if (temp == null) return;

        ItemNode newNode = new ItemNode(id, name, qty, price);
        newNode.Next = temp.Next;
        temp.Next = newNode;
    }

    // Remove by Item ID
    public void RemoveById(int id)
    {
        if (head == null) return;

        if (head.ItemId == id)
        {
            head = head.Next;
            Console.WriteLine("Item removed");
            return;
        }

        ItemNode temp = head;
        while (temp.Next != null && temp.Next.ItemId != id)
            temp = temp.Next;

        if (temp.Next != null)
        {
            temp.Next = temp.Next.Next;
            Console.WriteLine("Item removed");
        }
        else
            Console.WriteLine("Item not found");
    }

    // Update quantity
    public void UpdateQuantity(int id, int newQty)
    {
        ItemNode temp = head;
        while (temp != null)
        {
            if (temp.ItemId == id)
            {
                temp.Quantity = newQty;
                Console.WriteLine("Quantity updated");
                return;
            }
            temp = temp.Next;
        }
        Console.WriteLine("Item not found");
    }

    // Search by ID
    public void SearchById(int id)
    {
        ItemNode temp = head;
        while (temp != null)
        {
            if (temp.ItemId == id)
            {
                PrintItem(temp);
                return;
            }
            temp = temp.Next;
        }
        Console.WriteLine("Item not found");
    }

    // Search by Name
    public void SearchByName(string name)
    {
        ItemNode temp = head;
        bool found = false;

        while (temp != null)
        {
            if (temp.ItemName.Equals(name))
            {
                PrintItem(temp);
                found = true;
            }
            temp = temp.Next;
        }

        if (!found)
            Console.WriteLine("Item not found");
    }

    // Total inventory value
    public void TotalInventoryValue()
    {
        double total = 0;
        ItemNode temp = head;

        while (temp != null)
        {
            total += temp.Price * temp.Quantity;
            temp = temp.Next;
        }

        Console.WriteLine("Total Inventory Value: " + total);
    }

    // Sort by Name or Price (Bubble sort by swapping data)
    public void Sort(string criteria, bool ascending)
    {
        if (head == null) return;

        for (ItemNode i = head; i.Next != null; i = i.Next)
        {
            for (ItemNode j = i.Next; j != null; j = j.Next)
            {
                bool condition = false;

                if (criteria == "name")
                {
                    condition = ascending
                        ? string.Compare(i.ItemName, j.ItemName) > 0
                        : string.Compare(i.ItemName, j.ItemName) < 0;
                }
                else if (criteria == "price")
                {
                    condition = ascending
                        ? i.Price > j.Price
                        : i.Price < j.Price;
                }

                if (condition)
                    Swap(i, j);
            }
        }
    }

    // Display all items
    public void Display()
    {
        ItemNode temp = head;
        while (temp != null)
        {
            PrintItem(temp);
            temp = temp.Next;
        }
    }

    // Helpers
    private void Swap(ItemNode a, ItemNode b)
    {
        int id = a.ItemId;
        string name = a.ItemName;
        int qty = a.Quantity;
        double price = a.Price;

        a.ItemId = b.ItemId;
        a.ItemName = b.ItemName;
        a.Quantity = b.Quantity;
        a.Price = b.Price;

        b.ItemId = id;
        b.ItemName = name;
        b.Quantity = qty;
        b.Price = price;
    }

    private void PrintItem(ItemNode item)
    {
        Console.WriteLine($"ID:{item.ItemId}, Name:{item.ItemName}, Qty:{item.Quantity}, Price:{item.Price}");
    }
}

// Main
class Program
{
    static void Main()
    {
        Inventory inv = new Inventory();

        inv.AddAtEnd(1, "Laptop", 5, 50000);
        inv.AddAtEnd(2, "Mouse", 20, 500);
        inv.AddAtBeginning(3, "Keyboard", 10, 1500);

        Console.WriteLine("Inventory:");
        inv.Display();

        Console.WriteLine("\nUpdate Quantity:");
        inv.UpdateQuantity(2, 30);

        Console.WriteLine("\nSearch by Name:");
        inv.SearchByName("Laptop");

        Console.WriteLine("\nTotal Value:");
        inv.TotalInventoryValue();

        Console.WriteLine("\nSort by Price (Ascending):");
        inv.Sort("price", true);
        inv.Display();

        Console.WriteLine("\nRemove Item ID 1:");
        inv.RemoveById(1);
        inv.Display();
    }
}