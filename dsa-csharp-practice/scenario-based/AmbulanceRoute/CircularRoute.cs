using System;

public class CircularRoute : IHospitalRoute
{
    // Node represents a hospital unit
    private class Node
    {
        public string Unit;
        public Node Next;

        public Node(string unit)
        {
            Unit = unit;
            Next = null;
        }
    }

    private Node head;
    private Node current; // ambulance pointer

    // ================= ADD UNIT =================
    public void AddUnit(string unitName)
    {
        Node newNode = new Node(unitName);

        // First unit in the circular list
        if (head == null)
        {
            head = newNode;
            newNode.Next = head;
            current = head;
            return;
        }

        // Insert at end of circular list
        Node temp = head;
        while (temp.Next != head)
            temp = temp.Next;

        temp.Next = newNode;
        newNode.Next = head;
    }

    // ================= REMOVE UNIT =================
    public void RemoveUnit(string unitName)
    {
        if (head == null)
        {
            Console.WriteLine("No units available.");
            return;
        }

        Node curr = head;
        Node prev = null;

        do
        {
            if (curr.Unit.Equals(unitName, StringComparison.OrdinalIgnoreCase))
            {
                // If only one node exists
                if (curr == head && curr.Next == head)
                {
                    head = null;
                    current = null;
                }
                else
                {
                    if (curr == head)
                        head = head.Next;

                    if (curr == current)
                        current = curr.Next;

                    if (prev != null)
                        prev.Next = curr.Next;
                    else
                    {
                        // Removing head → fix last node link
                        Node last = head;
                        while (last.Next != curr)
                            last = last.Next;

                        last.Next = curr.Next;
                    }
                }

                Console.WriteLine($"Unit removed (maintenance): {unitName}");
                return;
            }

            prev = curr;
            curr = curr.Next;

        } while (curr != head);

        Console.WriteLine("Unit not found.");
    }

    // ================= REDIRECT PATIENT =================
    public void RedirectPatient()
    {
        if (current == null)
        {
            Console.WriteLine("No units available for emergency.");
            return;
        }

        Console.WriteLine($"Patient redirected to: {current.Unit}");
        current = current.Next; // move ambulance forward
    }

    // ================= DISPLAY ROUTE =================
    public void DisplayRoute()
    {
        if (head == null)
        {
            Console.WriteLine("Route is empty.");
            return;
        }

        Console.Write("Hospital Route: ");
        Node temp = head;

        do
        {
            Console.Write(temp.Unit + " → ");
            temp = temp.Next;
        }
        while (temp != head);

        Console.WriteLine("(back to Emergency)");
    }
}
