using System;
using System.Collections.Generic;

class Product
{
    public string ProductName;
    public double Price;

    public Product(string name, double price)
    {
        ProductName = name;
        Price = price;
    }

    public void DisplayProduct()
    {
        Console.WriteLine($"- {ProductName}: ${Price}");
    }
}

class Order
{
    public int OrderId;
    private List<Product> products;

    public Order(int id)
    {
        OrderId = id;
        products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public void DisplayOrder()
    {
        Console.WriteLine($"\nOrder ID: {OrderId}");
        double total = 0;
        foreach (Product p in products)
        {
            p.DisplayProduct();
            total += p.Price;
        }
        Console.WriteLine($"Total: ${total}");
    }
}

class Customer
{
    public string Name;
    private List<Order> orders;

    public Customer(string name)
    {
        Name = name;
        orders = new List<Order>();
    }

    public void PlaceOrder(Order order)
    {
        orders.Add(order);
        Console.WriteLine($"{Name} placed Order ID {order.OrderId}");
    }

    public void ShowOrders()
    {
        Console.WriteLine($"\nOrders of {Name}:");
        foreach (Order o in orders)
        {
            o.DisplayOrder();
        }
    }
}

class Program
{
    static void Main()
    {
        // Products (independent)
        Product laptop = new Product("Laptop", 1200);
        Product mouse = new Product("Mouse", 25);
        Product keyboard = new Product("Keyboard", 45);

        // Customer
        Customer alice = new Customer("Alice");

        // Orders
        Order order1 = new Order(101);
        order1.AddProduct(laptop);
        order1.AddProduct(mouse);

        Order order2 = new Order(102);
        order2.AddProduct(keyboard);

        // Customer places orders
        alice.PlaceOrder(order1);
        alice.PlaceOrder(order2);

        // Display customer orders
        alice.ShowOrders();
    }
}
