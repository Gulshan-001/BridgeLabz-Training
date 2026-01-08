using System;

class Program
{
    static void Main()
    {
        // Polymorphism using interface array
        IControllable[] appliances =
        {
            new Light("Bedroom"),
            new Fan("Hall"),
            new AC("Living Room")
        };

        Console.WriteLine("Turning ON:");
        foreach (IControllable a in appliances)
        {
            a.TurnOn();
        }

        Console.WriteLine("\nTurning OFF:");
        foreach (IControllable a in appliances)
        {
            a.TurnOff();
        }
    }
}
