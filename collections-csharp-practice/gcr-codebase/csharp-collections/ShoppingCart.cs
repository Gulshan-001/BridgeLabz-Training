using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Stores product → price (fast lookup)
        Dictionary<string, double> priceMap = new Dictionary<string, double>();

        // Maintains insertion order (LinkedDictionary behavior)
        List<string> insertionOrder = new List<string>();

        // Add items to cart
        AddItem("Apple", 120.50);
        AddItem("Banana", 40.00);
        AddItem("Milk", 60.00);
        AddItem("Bread", 40.00);
        AddItem("Apple", 120.50); // duplicate add

        Console.WriteLine("\nCart Items (Insertion Order):");
        DisplayCart();

        Console.WriteLine("\nCart Items Sorted by Price:");
        DisplaySortedByPrice();

        // ---------- LOCAL FUNCTIONS ----------

        void AddItem(string product, double price)
        {
            // Avoid duplicate product entries
            if (priceMap.ContainsKey(product))
            {
                Console.WriteLine($"Duplicate item ignored: {product}");
                return;
            }

            priceMap[product] = price;
            insertionOrder.Add(product);
        }

        void DisplayCart()
        {
            foreach (var product in insertionOrder)
            {
                Console.WriteLine($"{product} → ₹{priceMap[product]}");
            }
        }

        void DisplaySortedByPrice()
        {
            // TreeMap equivalent: price → list of products
            SortedDictionary<double, List<string>> sorted =
                new SortedDictionary<double, List<string>>();

            foreach (var pair in priceMap)
            {
                if (!sorted.ContainsKey(pair.Value))
                    sorted[pair.Value] = new List<string>();

                sorted[pair.Value].Add(pair.Key);
            }

            foreach (var entry in sorted)
            {
                foreach (var product in entry.Value)
                {
                    Console.WriteLine($"{product} → ₹{entry.Key}");
                }
            }
        }
    }
}
