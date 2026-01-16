using System;

class VehicleQueue
{
    private QueueNode front;
    private QueueNode rear;
    private int capacity;
    private int size;

    public VehicleQueue(int capacity)
    {
        this.capacity = capacity;
        front = null;
        rear = null;
        size = 0;
    }

    // ADD VEHICLE TO QUEUE
    public bool Enqueue(Vehicle vehicle)
    {
        if (size == capacity)
        {
            Console.WriteLine("Waiting queue is FULL");
            return false;
        }

        QueueNode newNode = new QueueNode(vehicle);

        if (rear == null)
        {
            // first vehicle in queue
            front = rear = newNode;
        }
        else
        {
            rear.Next = newNode;
            rear = newNode;
        }

        size++;
        return true;
    }

    // REMOVE VEHICLE FROM QUEUE
    public Vehicle Dequeue()
    {
        if (front == null)
        {
            Console.WriteLine("Waiting queue is EMPTY");
            return null;
        }

        Vehicle vehicle = front.Data;
        front = front.Next;

        if (front == null)
        {
            rear = null;
        }

        size--;
        return vehicle;
    }

    // CHECK IF QUEUE IS EMPTY
    public bool IsEmpty()
    {
        return size == 0;
    }

    // DISPLAY WAITING QUEUE
    public void DisplayQueue()
    {
        if (front == null)
        {
            Console.WriteLine("No vehicles waiting");
            return;
        }

        Console.WriteLine("Vehicles waiting to enter:");

        QueueNode temp = front;
        while (temp != null)
        {
            Console.WriteLine(
                temp.Data.VehicleId + " - " +
                temp.Data.VehicleNumber
            );
            temp = temp.Next;
        }
    }
}
