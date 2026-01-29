using System;

public class UserInterface
{
    public static void processInput()
    {
        IFlightUtil flightUtil = new FlightUtil();

        Console.WriteLine("Enter flight details");
        string input = Console.ReadLine();

        try
        {
            string[] data = input.Split(':');

            string flightNumber = data[0];
            string flightName = data[1];
            int passengerCount = int.Parse(data[2]);
            double fuelLevel = double.Parse(data[3]);

            flightUtil.validateFlightNumber(flightNumber);
            flightUtil.validateFlightName(flightName);
            flightUtil.validatePassengerCount(passengerCount, flightName);

            double fuelRequired =
                flightUtil.calculateFuelToFillTank(flightName, fuelLevel);

            Console.WriteLine(
                "Fuel required to fill the tank: " + fuelRequired + " liters"
            );
        }
        catch (InvalidFlightException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (Exception)
        {
            // handles parsing errors safely
            Console.WriteLine("Invalid input format");
        }
    }
}