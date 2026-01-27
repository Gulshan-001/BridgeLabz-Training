using System;
using System.Reflection;

class Person
{
    private int age;

    public Person(int age)
    {
        this.age = age;
    }
}

class Program
{
    static void Main()
    {
        // Create object
        Person person = new Person(25);

        // Get Type information
        Type type = typeof(Person);

        // Access private field 'age'
        FieldInfo ageField = type.GetField(
            "age",
            BindingFlags.NonPublic | BindingFlags.Instance
        );

        // Modify private field value
        ageField.SetValue(person, 30);

        // Retrieve updated value
        int updatedAge = (int)ageField.GetValue(person);

        Console.WriteLine("Updated Age: " + updatedAge);
    }
}
