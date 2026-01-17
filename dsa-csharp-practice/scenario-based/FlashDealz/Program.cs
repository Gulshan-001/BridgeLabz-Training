using System;

class Program
{
    static void Main()
    {
        Product[] products =
        {
            new Product(1, "Laptop", 35),
            new Product(2, "Mobile", 50),
            new Product(3, "Headphones", 20),
            new Product(4, "Smart Watch", 45),
            new Product(5, "Camera", 30)
        };

        Console.WriteLine("Before Sorting:");
        Display(products);

        // interface reference
        ISortOperations sorter = new QuickSortByDiscount();
        sorter.Sort(products);

        Console.WriteLine("\nAfter Sorting (Top Discounts First):");
        Display(products);
    }

    static void Display(Product[] products)
    {
        for (int i = 0; i < products.Length; i++)
        {
            Console.WriteLine(
                products[i].ProductId + " | " +
                products[i].Name + " | Discount: " +
                products[i].Discount + "%"
            );
        }
    }
}
