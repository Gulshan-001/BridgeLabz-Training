using System;

class Fan : Appliance, IControllable
{
    public Fan(string name) : base(name) { }

    public void TurnOn()
    {
        Console.WriteLine(name + " fan is spinning");
    }

    public void TurnOff()
    {
        Console.WriteLine(name + " fan is stopped");
    }
}
