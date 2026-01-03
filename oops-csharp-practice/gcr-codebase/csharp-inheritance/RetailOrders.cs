using System;

// Base class
class Order
{
    public int OrderId;
    public string OrderDate;

    public Order(int orderId, string orderDate)
    {
        OrderId = orderId;
        OrderDate = orderDate;
    }

    public virtual string GetOrderStatus()
    {
        return "Order Placed";
    }
}

// First level child
class ShippedOrder : Order
{
    public string TrackingNumber;

    public ShippedOrder(int orderId, string orderDate, string trackingNumber)
        : base(orderId, orderDate)
    {
        TrackingNumber = trackingNumber;
    }

    public override string GetOrderStatus()
    {
        return "Order Shipped";
    }
}

// Second level child
class DeliveredOrder : ShippedOrder
{
    public string DeliveryDate;

    public DeliveredOrder(int orderId, string orderDate, string trackingNumber, string deliveryDate)
        : base(orderId, orderDate, trackingNumber)
    {
        DeliveryDate = deliveryDate;
    }

    public override string GetOrderStatus()
    {
        return "Order Delivered";
    }
}

class Program
{
    static void Main()
    {
        Order o1 = new Order(101, "10-Jan-2026");
        Order o2 = new ShippedOrder(102, "11-Jan-2026", "TRK123");
        Order o3 = new DeliveredOrder(103, "12-Jan-2026", "TRK456", "15-Jan-2026");

        Console.WriteLine(o1.GetOrderStatus());
        Console.WriteLine(o2.GetOrderStatus());
        Console.WriteLine(o3.GetOrderStatus());
    }
}
