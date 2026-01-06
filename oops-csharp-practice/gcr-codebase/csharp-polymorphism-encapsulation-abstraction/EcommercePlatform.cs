using System;
using System.Collections.Generic;

// Tax interface
interface ITaxable
{
    double CalculateTax();
    string GetTaxDetails();
}

// Abstract Product class
abstract class Product
{
    // Encapsulation
    private int productId;
    private string name;
    protected double price;

    // Setters only (controlled access)
    public void SetProductId(int id)
    {
        productId = id;
    }

    public void SetName(string n)
    {
        name = n;
    }

    public void SetPrice(double p)
    {
        price = p;
    }

    public string GetName()
    {
        return name;
    }

    // Abstract discount method
    public abstract double CalculateDiscount();

    // Final price logic (polymorphism happens here)
    public void PrintFinalPrice()
    {
        double tax = 0;

        if (this is ITaxable)
        {
            tax = ((ITaxable)this).CalculateTax();
        }

        double discount = CalculateDiscount();
        double finalPrice = price + tax - discount;

        Console.WriteLine("Product: " + name);
        Console.WriteLine("Final Price: " + finalPrice);
        Console.WriteLine("-------------------");
    }
}

// Electronics product
class Electronics : Product, ITaxable
{
    public override double CalculateDiscount()
    {
        return price * 0.10; // 10% discount
    }

    public double CalculateTax()
    {
        return price * 0.18; // 18% GST
    }

    public string GetTaxDetails()
    {
        return "Electronics Tax Applied";
    }
}

// Clothing product
class Clothing : Product, ITaxable
{
    public override double CalculateDiscount()
    {
        return price * 0.20; // 20% discount
    }

    public double CalculateTax()
    {
        return price * 0.05; // 5% tax
    }

    public string GetTaxDetails()
    {
        return "Clothing Tax Applied";
    }
}

// Grocery product (no tax here)
class Groceries : Product
{
    public override double CalculateDiscount()
    {
        return price * 0.05; // small discount
    }
}

class Program
{
    static void Main()
    {
        List<Product> products = new List<Product>();

        Electronics p1 = new Electronics();
        p1.SetProductId(101);
        p1.SetName("Laptop");
        p1.SetPrice(60000);

        Clothing p2 = new Clothing();
        p2.SetProductId(102);
        p2.SetName("Jacket");
        p2.SetPrice(3000);

        Groceries p3 = new Groceries();
        p3.SetProductId(103);
        p3.SetName("Rice Bag");
        p3.SetPrice(1200);

        products.Add(p1);
        products.Add(p2);
        products.Add(p3);

        // Polymorphism in action
        foreach (Product p in products)
        {
            p.PrintFinalPrice();
        }
    }
}