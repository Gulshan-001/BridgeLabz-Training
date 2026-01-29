using System;
using System.Text.RegularExpressions;

public class FlightUtil : IFlightUtil
{
    public bool validateFlightNumber(string flightNumber)
    {
        if (!Regex.IsMatch(flightNumber, @"FL-[1-9][0-9]{3}"))
        {
            throw new InvalidFlightException(
                "The flight number " + flightNumber + " is invalid"
            );
        }
        return true;
    }

    public bool validateFlightName(string flightName)
    {
        if (!(flightName.Equals("SpiceJet") ||
              flightName.Equals("Vistara") ||
              flightName.Equals("IndiGo") ||
              flightName.Equals("Air Arabia")))
        {
            throw new InvalidFlightException(
                "The flight name " + flightName + " is invalid"
            );
        }
        return true;
    }

    public bool validatePassengerCount(int passengerCount, string flightName)
    {
        int maxCapacity = flightName switch
        {
            "SpiceJet" => 396,
            "Vistara" => 615,
            "IndiGo" => 230,
            "Air Arabia" => 130,
            _ => 0
        };

        if (passengerCount <= 0 || passengerCount > maxCapacity)
        {
            throw new InvalidFlightException(
                "The passenger count " + passengerCount + " is invalid for " + flightName
            );
        }
        return true;
    }

    public double calculateFuelToFillTank(string flightName, double currentFuelLevel)
    {
        double maxFuel = flightName switch
        {
            "SpiceJet" => 200000,
            "Vistara" => 300000,
            "IndiGo" => 250000,
            "Air Arabia" => 150000,
            _ => 0
        };

        if (currentFuelLevel < 0 || currentFuelLevel > maxFuel)
        {
            throw new InvalidFlightException(
                "Invalid fuel level for " + flightName
            );
        }

        return maxFuel - currentFuelLevel;
    }
}
