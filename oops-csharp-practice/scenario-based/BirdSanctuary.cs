using System;

// ================= BASE CLASS =================
class Bird
{
    public string Name;

    public Bird(string name)
    {
        Name = name;
    }
}

// ================= INTERFACES =================
interface IFlyable
{
    void Fly();
}

interface ISwimmable
{
    void Swim();
}

// ================= DERIVED CLASSES =================
class Eagle : Bird, IFlyable
{
    public Eagle(string name) : base(name) { }

    public void Fly()
    {
        Console.WriteLine($"{Name} (Eagle) is soaring high in the sky.");
    }
}

class Sparrow : Bird, IFlyable
{
    public Sparrow(string name) : base(name) { }

    public void Fly()
    {
        Console.WriteLine($"{Name} (Sparrow) is flying swiftly.");
    }
}

class Duck : Bird, ISwimmable
{
    public Duck(string name) : base(name) { }

    public void Swim()
    {
        Console.WriteLine($"{Name} (Duck) is swimming in the pond.");
    }
}

class Penguin : Bird, ISwimmable
{
    public Penguin(string name) : base(name) { }

    public void Swim()
    {
        Console.WriteLine($"{Name} (Penguin) is swimming in cold water.");
    }
}

class Seagull : Bird, IFlyable, ISwimmable
{
    public Seagull(string name) : base(name) { }

    public void Fly()
    {
        Console.WriteLine($"{Name} (Seagull) is flying near the sea.");
    }

    public void Swim()
    {
        Console.WriteLine($"{Name} (Seagull) is swimming on the water surface.");
    }
}

// ================= MAIN PROGRAM =================
class Program
{
    static void Main()
    {
        // Array of birds (Polymorphism)
        Bird[] birds =
        {
            new Eagle("Golden Eagle"),
            new Sparrow("House Sparrow"),
            new Duck("Mallard Duck"),
            new Penguin("Emperor Penguin"),
            new Seagull("White Seagull")
        };

        Console.WriteLine(" EcoWing Bird Sanctuary Activities ");

        foreach (Bird bird in birds)
        {
            Console.WriteLine($"Bird: {bird.Name}");

            if (bird is IFlyable flyable)
                flyable.Fly();

            if (bird is ISwimmable swimmable)
                swimmable.Swim();

            Console.WriteLine();
        }
    }
}
