using System;
using System.Collections.Generic;

public class CustomerQueue
{
    public class Customer
    {
        public string Name;
        public List<string> Items;
    }

    private Queue<Customer> queue = new Queue<Customer>();

    public void Enqueue(Customer customer)
    {
        queue.Enqueue(customer);
    }

    public Customer Dequeue()
    {
        return queue.Count > 0 ? queue.Dequeue() : null;
    }

    public bool IsEmpty()
    {
        return queue.Count == 0;
    }

    public void Display()
    {
        if (queue.Count == 0)
        {
            Console.WriteLine("Queue is empty.\n");
            return;
        }

        Console.WriteLine("Customers in queue:");
        foreach (var customer in queue)
        {
            Console.WriteLine($"- {customer.Name}");
        }
        Console.WriteLine();
    }
}
