using System;

// Node for Circular Linked List
class Ticket
{
    public int ticketId;
    public string customerName;
    public string movieName;
    public string seatNumber;
    public string bookingTime;   // kept simple as string

    public Ticket next;

    public Ticket(int id, string cname, string mname, string seat, string time)
    {
        ticketId = id;
        customerName = cname;
        movieName = mname;
        seatNumber = seat;
        bookingTime = time;
        next = null;
    }
}

// Ticket Reservation System
class TicketReservation
{
    private Ticket head = null;

    // Add ticket at end
    public void AddTicket(int id, string cname, string mname, string seat, string time)
    {
        Ticket newTicket = new Ticket(id, cname, mname, seat, time);

        // first ticket
        if (head == null)
        {
            head = newTicket;
            newTicket.next = head;
            return;
        }

        Ticket temp = head;
        while (temp.next != head)
        {
            temp = temp.next;
        }

        temp.next = newTicket;
        newTicket.next = head;
    }

    // Remove ticket by ID
    public void RemoveTicket(int id)
    {
        if (head == null)
        {
            Console.WriteLine("No tickets booked");
            return;
        }

        Ticket curr = head;
        Ticket prev = null;

        do
        {
            if (curr.ticketId == id)
            {
                // only one node
                if (curr == head && curr.next == head)
                {
                    head = null;
                }
                // deleting head
                else if (curr == head)
                {
                    prev = head;
                    while (prev.next != head)
                        prev = prev.next;

                    head = head.next;
                    prev.next = head;
                }
                else
                {
                    prev.next = curr.next;
                }

                Console.WriteLine("Ticket removed");
                return;
            }

            prev = curr;
            curr = curr.next;

        } while (curr != head);

        Console.WriteLine("Ticket not found");
    }

    // Display all tickets
    public void DisplayTickets()
    {
        if (head == null)
        {
            Console.WriteLine("No tickets to display");
            return;
        }

        Ticket temp = head;
        Console.WriteLine("\nBooked Tickets:");
        do
        {
            Console.WriteLine(
                "ID: " + temp.ticketId +
                ", Customer: " + temp.customerName +
                ", Movie: " + temp.movieName +
                ", Seat: " + temp.seatNumber +
                ", Time: " + temp.bookingTime
            );

            temp = temp.next;
        } while (temp != head);
    }

    // Search ticket by customer or movie
    public void Search(string keyword)
    {
        if (head == null)
        {
            Console.WriteLine("No tickets booked");
            return;
        }

        Ticket temp = head;
        bool found = false;

        do
        {
            if (temp.customerName == keyword || temp.movieName == keyword)
            {
                Console.WriteLine("Found Ticket -> ID: " + temp.ticketId);
                found = true;
            }
            temp = temp.next;
        } while (temp != head);

        if (!found)
            Console.WriteLine("No matching ticket found");
    }

    // Count total tickets
    public int CountTickets()
    {
        if (head == null) return 0;

        int count = 0;
        Ticket temp = head;

        do
        {
            count++;
            temp = temp.next;
        } while (temp != head);

        return count;
    }
}

// Main class
class Program
{
    static void Main()
    {
        TicketReservation system = new TicketReservation();

        system.AddTicket(1, "Alice", "Inception", "A1", "10:00 AM");
        system.AddTicket(2, "Bob", "Avatar", "B2", "10:05 AM");
        system.AddTicket(3, "Alice", "Inception", "A2", "10:10 AM");

        system.DisplayTickets();

        system.Search("Alice");
        system.Search("Avatar");

        Console.WriteLine("\nTotal Tickets: " + system.CountTickets());

        system.RemoveTicket(2);
        system.DisplayTickets();

        Console.WriteLine("\nTotal Tickets: " + system.CountTickets());
    }
}