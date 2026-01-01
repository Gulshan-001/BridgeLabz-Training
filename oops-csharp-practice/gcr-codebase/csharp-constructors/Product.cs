using System;

class Product
{
    string productName;
    double price;

    static int totalProducts = 0;

    public Product(string name, double p)
    {
        productName = name;
        price = p;

        // Every time a product object is created, count increases
        totalProducts++;
    }

    public void DisplayProductDetails()
    {
        Console.WriteLine("Product Name: " + productName);
        Console.WriteLine("Price: " + price);
    }

    public static void DisplayTotalProducts()
    {
        Console.WriteLine("Total Products Created: " + totalProducts);
    }
}

class Program
{
    static void Main()
    {
        Product p1 = new Product("Laptop", 65000);
        Product p2 = new Product("Mouse", 1200);
        Product p3 = new Product("Keyboard", 2500);

        Console.WriteLine("Product 1 Details:");
        p1.DisplayProductDetails();
        Console.WriteLine();

        Console.WriteLine("Product 2 Details:");
        p2.DisplayProductDetails();
        Console.WriteLine();

        Product.DisplayTotalProducts();
    }
}
