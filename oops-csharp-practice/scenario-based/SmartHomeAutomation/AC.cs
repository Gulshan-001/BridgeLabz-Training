using System;

class AC : Appliance, IControllable
{
    public AC(string name) : base(name) { }

    public void TurnOn()
    {
        Console.WriteLine(name + " AC is cooling");
    }

    public void TurnOff()
    {
        Console.WriteLine(name + " AC is OFF");
    }
}
