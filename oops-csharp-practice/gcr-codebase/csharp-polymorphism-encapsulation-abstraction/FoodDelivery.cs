using System;
using System.Collections.Generic;

// Discount interface
interface IDiscountable
{
    double ApplyDiscount();
    string GetDiscountDetails();
}

// Abstract FoodItem class
abstract class FoodItem
{
    protected string itemName;
    protected double price;
    protected int quantity;

    public FoodItem(string name, double price, int qty)
    {
        itemName = name;
        this.price = price;
        quantity = qty;
    }

    // abstract method
    public abstract double CalculateTotalPrice();

    // common method
    public void GetItemDetails()
    {
        Console.WriteLine("Item: " + itemName);
        Console.WriteLine("Quantity: " + quantity);
        Console.WriteLine("Total Price: " + CalculateTotalPrice());
        Console.WriteLine("--------------------");
    }
}

// Veg food
class VegItem : FoodItem, IDiscountable
{
    public VegItem(string name, double price, int qty)
        : base(name, price, qty) { }

    public override double CalculateTotalPrice()
    {
        return price * quantity; // no extra charge
    }

    public double ApplyDiscount()
    {
        return CalculateTotalPrice() * 0.10; // 10% off
    }

    public string GetDiscountDetails()
    {
        return "Veg Discount: 10%";
    }
}

// Non-Veg food
class NonVegItem : FoodItem, IDiscountable
{
    public NonVegItem(string name, double price, int qty)
        : base(name, price, qty) { }

    public override double CalculateTotalPrice()
    {
        return (price * quantity) + 50; // extra charge
    }

    public double ApplyDiscount()
    {
        return CalculateTotalPrice() * 0.05; // 5% off
    }

    public string GetDiscountDetails()
    {
        return "Non-Veg Discount: 5%";
    }
}

class Program
{
    static void Main()
    {
        List<FoodItem> order = new List<FoodItem>();

        order.Add(new VegItem("Paneer Butter Masala", 200, 2));
        order.Add(new NonVegItem("Chicken Biryani", 250, 1));

        // polymorphism
        foreach (FoodItem item in order)
        {
            item.GetItemDetails();
        }
    }
}
