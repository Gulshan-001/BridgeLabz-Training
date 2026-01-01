using System;

class Person
{
    string name;
    int age;

    // Parameterized constructor
    public Person(string n, int a)
    {
        name = n;
        age = a;
    }

    // Copy constructor
    public Person(Person other)
    {
        // Copying values from the existing object
        name = other.name;
        age = other.age;
    }

    public void DisplayPerson()
    {
        Console.WriteLine("Name: " + name);
        Console.WriteLine("Age: " + age);
    }
}

class Program
{
    static void Main()
    {
        // Original person object
        Person p1 = new Person("Gulshan", 22);

        // New object created by copying p1
        Person p2 = new Person(p1);

        Console.WriteLine("Original Person:");
        p1.DisplayPerson();

        Console.WriteLine();

        Console.WriteLine("Copied Person:");
        p2.DisplayPerson();
    }
}
