using System;
using System.Collections.Generic;

public class ItemStore
{
    private class Item
    {
        public int Price;
        public int Stock;
    }

    // HashMap for fast item lookup
    private Dictionary<string, Item> items = new Dictionary<string, Item>();

    public ItemStore()
    {
        // Preload supermarket items
        items["Milk"] = new Item { Price = 50, Stock = 20 };
        items["Bread"] = new Item { Price = 30, Stock = 15 };
        items["Rice"] = new Item { Price = 60, Stock = 25 };
        items["Sugar"] = new Item { Price = 45, Stock = 10 };
    }

    public bool IsAvailable(string name)
    {
        return items.ContainsKey(name) && items[name].Stock > 0;
    }

    public int GetPrice(string name)
    {
        return items[name].Price;
    }

    public void ReduceStock(string name)
    {
        items[name].Stock--;
    }

    public int GetStock(string name)
    {
        return items[name].Stock;
    }
}
