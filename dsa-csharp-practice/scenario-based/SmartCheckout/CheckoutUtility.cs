using System;
using System.Collections.Generic;

public class CheckoutUtility : ICheckoutSystem
{
    private CustomerQueue customerQueue = new CustomerQueue();
    private ItemStore itemStore = new ItemStore();

    public void AddCustomer()
    {
        Console.Write("Enter customer name: ");
        string name = Console.ReadLine();

        Console.Write("Enter number of items: ");
        int count = int.Parse(Console.ReadLine());

        List<string> items = new List<string>();

        for (int i = 0; i < count; i++)
        {
            Console.Write($"Enter item {i + 1}: ");
            items.Add(Console.ReadLine());
        }

        customerQueue.Enqueue(new CustomerQueue.Customer
        {
            Name = name,
            Items = items
        });

        Console.WriteLine("Customer added to queue.\n");
    }

    public void ServeCustomer()
    {
        if (customerQueue.IsEmpty())
        {
            Console.WriteLine("No customers to serve.\n");
            return;
        }

        var customer = customerQueue.Dequeue();
        int total = 0;

        Console.WriteLine($"Serving customer: {customer.Name}");

        foreach (var item in customer.Items)
        {
            // Price lookup and stock check from HashMap
            if (itemStore.IsAvailable(item))
            {
                total += itemStore.GetPrice(item);
                itemStore.ReduceStock(item);

                Console.WriteLine(
                    $"{item} - ₹{itemStore.GetPrice(item)} (Stock left: {itemStore.GetStock(item)})"
                );
            }
            else
            {
                Console.WriteLine($"{item} is unavailable.");
            }
        }

        Console.WriteLine($"Total Bill: ₹{total}\n");
    }

    public void ShowQueue()
    {
        customerQueue.Display();
    }
}
