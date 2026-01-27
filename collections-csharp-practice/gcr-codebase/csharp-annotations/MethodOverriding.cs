using System;

class Animal
{
    // Step 1: Virtual method in parent class
    public virtual void MakeSound()
    {
        Console.WriteLine("Animal makes a sound");
    }
}

class Dog : Animal
{
    // Step 2: Override method in child class
    public override void MakeSound()
    {
        Console.WriteLine("Dog barks");
    }
}

class Program
{
    static void Main()
    {
        // Step 3: Instantiate Dog and call method
        Animal animal = new Dog();
        animal.MakeSound();
    }
}
