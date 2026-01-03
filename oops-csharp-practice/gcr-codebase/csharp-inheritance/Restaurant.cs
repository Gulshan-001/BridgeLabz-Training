using System;

// Interface
interface Worker
{
    void PerformDuties();
}

// Superclass
class Person
{
    public string Name;
    public int Id;

    public Person(string name, int id)
    {
        Name = name;
        Id = id;
    }
}

// Chef class
class Chef : Person, Worker
{
    public Chef(string name, int id)
        : base(name, id)
    {
    }

    public void PerformDuties()
    {
        Console.WriteLine(Name + " is cooking food.");
    }
}

// Waiter class
class Waiter : Person, Worker
{
    public Waiter(string name, int id)
        : base(name, id)
    {
    }

    public void PerformDuties()
    {
        Console.WriteLine(Name + " is serving food to customers.");
    }
}

class Program
{
    static void Main()
    {
        Worker w1 = new Chef("Rahul", 1);
        Worker w2 = new Waiter("Ankit", 2);

        w1.PerformDuties();
        w2.PerformDuties();
    }
}
