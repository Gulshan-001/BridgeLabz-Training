using System;

class HotelBooking
{
    string guestName;
    string roomType;
    int nights;

    // Default constructor
    public HotelBooking()
    {
        guestName = "Guest";
        roomType = "Standard";
        nights = 1;
    }

    // Parameterized constructor
    public HotelBooking(string name, string room, int stayNights)
    {
        guestName = name;
        roomType = room;
        nights = stayNights;
    }

    // Copy constructor
    public HotelBooking(HotelBooking other)
    {
        // Copying values from existing booking
        guestName = other.guestName;
        roomType = other.roomType;
        nights = other.nights;
    }

    public void DisplayBooking()
    {
        Console.WriteLine("Guest Name: " + guestName);
        Console.WriteLine("Room Type: " + roomType);
        Console.WriteLine("Nights: " + nights);
    }
}

class Program
{
    static void Main()
    {
        // Default booking
        HotelBooking booking1 = new HotelBooking();
        Console.WriteLine("Default Booking:");
        booking1.DisplayBooking();

        Console.WriteLine();

        // Parameterized booking
        HotelBooking booking2 = new HotelBooking("Gulshan", "Deluxe", 3);
        Console.WriteLine("Parameterized Booking:");
        booking2.DisplayBooking();

        Console.WriteLine();

        // Copy booking
        HotelBooking booking3 = new HotelBooking(booking2);
        Console.WriteLine("Copied Booking:");
        booking3.DisplayBooking();
    }
}
