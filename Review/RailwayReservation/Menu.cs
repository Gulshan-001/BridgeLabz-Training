using System;
namespace RailwayReservation
{
    public class Menu
    {
        private IPassenger passengerUtility;

        public Menu()
        {
            passengerUtility = new PassengerUtility();
        }
        public void ShowMenu()
        {
            while(true){
            Console.WriteLine("Railway Reservation System Menu:");
            Console.WriteLine("1. Add Passenger");
            Console.WriteLine("2. Search Passenger");
            Console.WriteLine("3. Sort Passengers");
            Console.WriteLine("4. Display Passengers");
            Console.WriteLine("5. Exit");
            Console.WriteLine("Select an option (1-5):");
            int choice=int.Parse(Console.ReadLine());
            switch (choice)
                {
                    case 1:
                        passengerUtility.addPassengers();
                        break;
                    case 2:
                        Console.Write("Enter PNR to search: ");
                        int pnr = int.Parse(Console.ReadLine());
                        Passenger p = passengerUtility.SearchPassenger(pnr);
                        if (p != null)
                        {
                        Console.WriteLine($"Found: {p.Name}");
                        Console.WriteLine($"Fare: {p.CalculateFare(500)}");
                        }
                        else
                        {
                        Console.WriteLine("Passenger not found!");
                        }
                        break;
                    case 3:
                        passengerUtility.sortPassengers();
                        break;
                    case 4:
                        passengerUtility.displayPassengers();
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Invalid choice\n");
                        break;
                }
        }
        }
    }
}