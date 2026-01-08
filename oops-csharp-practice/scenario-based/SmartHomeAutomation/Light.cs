using System;

class Light : Appliance, IControllable
{
    public Light(string name) : base(name) { }

    public void TurnOn()
    {
        Console.WriteLine(name + " light is ON");
    }

    public void TurnOff()
    {
        Console.WriteLine(name + " light is OFF");
    }
}
