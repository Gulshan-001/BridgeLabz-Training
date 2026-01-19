using System;

class Storage<T> where T : WarehouseItem
{
    private T[] items;
    private int count;

    public Storage(int capacity)
    {
        items = new T[capacity];
        count = 0;
    }

    public void AddItem(T item)
    {
        if (count >= items.Length)
        {
            Console.WriteLine("Storage full");
            return;
        }

        items[count] = item;
        count++;
    }

    public void DisplayItems()
    {
        for (int i = 0; i < count; i++)
        {
            items[i].Display();
        }
    }
}
