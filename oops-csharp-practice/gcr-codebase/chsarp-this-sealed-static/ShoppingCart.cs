using System;

class Product
{
    // Static discount shared by all products
    public static double Discount = 10; // percentage

    public readonly int ProductID;
    public string ProductName;
    public double Price;
    public int Quantity;

    public Product(int productID, string productName, double price, int quantity)
    {
        // Using this to assign values to current object
        this.ProductID = productID;
        this.ProductName = productName;
        this.Price = price;
        this.Quantity = quantity;
    }

    public double CalculateFinalPrice()
    {
        double total = Price * Quantity;
        double discountAmount = total * Discount / 100;
        return total - discountAmount;
    }

    public void DisplayProductDetails()
    {
        Console.WriteLine("Product ID: " + ProductID);
        Console.WriteLine("Product Name: " + ProductName);
        Console.WriteLine("Price: " + Price);
        Console.WriteLine("Quantity: " + Quantity);
        Console.WriteLine("Discount: " + Discount + "%");
        Console.WriteLine("Final Price: " + CalculateFinalPrice());
    }

    public static void UpdateDiscount(double newDiscount)
    {
        // Updating discount for all products
        Discount = newDiscount;
    }
}

class Program
{
    static void Main()
    {
        Product p1 = new Product(101, "Laptop", 60000, 1);
        Product p2 = new Product(102, "Headphones", 3000, 2);

        Console.WriteLine("Before Discount Update:");

        // Using is operator before processing
        if (p1 is Product)
        {
            p1.DisplayProductDetails();
        }

        Console.WriteLine();

        if (p2 is Product)
        {
            p2.DisplayProductDetails();
        }

        Console.WriteLine();

        // Update discount for all products
        Product.UpdateDiscount(20);

        Console.WriteLine("After Discount Update:");
        p1.DisplayProductDetails();
        Console.WriteLine();
        p2.DisplayProductDetails();
    }
}
