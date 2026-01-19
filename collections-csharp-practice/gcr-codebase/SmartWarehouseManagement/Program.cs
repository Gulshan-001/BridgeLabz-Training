using System;

class Program
{
    static void Main()
    {
        Storage<Electronics> electronicsStore = new Storage<Electronics>(5);
        Storage<Groceries> groceryStore = new Storage<Groceries>(5);
        Storage<Furniture> furnitureStore = new Storage<Furniture>(5);

        electronicsStore.AddItem(new Electronics("Laptop"));
        electronicsStore.AddItem(new Electronics("Mobile"));

        groceryStore.AddItem(new Groceries("Rice"));
        groceryStore.AddItem(new Groceries("Milk"));

        furnitureStore.AddItem(new Furniture("Chair"));
        furnitureStore.AddItem(new Furniture("Table"));

        Console.WriteLine("Electronics Warehouse:");
        electronicsStore.DisplayItems();

        Console.WriteLine("\nGroceries Warehouse:");
        groceryStore.DisplayItems();

        Console.WriteLine("\nFurniture Warehouse:");
        furnitureStore.DisplayItems();
    }
}