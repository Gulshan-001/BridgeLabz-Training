using System;

class CircularRoundabout
{
    private RoundaboutNode head;
    private int capacity;
    private int currentSize;

    public CircularRoundabout(int capacity)
    {
        this.capacity = capacity;
        head = null;
        currentSize = 0;
    }

    // ADD VEHICLE TO ROUNDABOUT
    public bool AddVehicle(Vehicle vehicle)
    {
        if (currentSize == capacity)
        {
            // roundabout full
            return false;
        }

        RoundaboutNode newNode = new RoundaboutNode(vehicle);

        // first vehicle
        if (head == null)
        {
            head = newNode;
            newNode.Next = head;   // circular link
        }
        else
        {
            RoundaboutNode temp = head;
            while (temp.Next != head)
            {
                temp = temp.Next;
            }

            temp.Next = newNode;
            newNode.Next = head;
        }

        currentSize++;
        return true;
    }

    // REMOVE VEHICLE BY ID
    public bool RemoveVehicle(int vehicleId)
    {
        if (head == null)
            return false;

        RoundaboutNode current = head;
        RoundaboutNode previous = null;

        do
        {
            if (current.Data.VehicleId == vehicleId)
            {
                // only one vehicle
                if (current.Next == head && current == head)
                {
                    head = null;
                }
                else
                {
                    if (current == head)
                    {
                        // removing head
                        RoundaboutNode temp = head;
                        while (temp.Next != head)
                        {
                            temp = temp.Next;
                        }
                        head = head.Next;
                        temp.Next = head;
                    }
                    else
                    {
                        previous.Next = current.Next;
                    }
                }

                currentSize--;
                return true;
            }

            previous = current;
            current = current.Next;

        } while (current != head);

        return false;
    }

    // DISPLAY ROUNDABOUT STATE
    public void DisplayRoundabout()
    {
        if (head == null)
        {
            Console.WriteLine("Roundabout is empty");
            return;
        }

        Console.WriteLine("Vehicles in roundabout:");

        RoundaboutNode temp = head;
        do
        {
            Console.WriteLine(
                temp.Data.VehicleId + " - " +
                temp.Data.VehicleNumber
            );
            temp = temp.Next;

        } while (temp != head);
    }

    // CHECK AVAILABLE SPACE
    public bool HasSpace()
    {
        return currentSize < capacity;
    }
}
