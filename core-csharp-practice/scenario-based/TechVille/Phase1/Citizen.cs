using System;

namespace TechVille_Phase1
{
    public class Citizen
    {
        public string Name;
        public int Age;
        public double Income;
        public int ResidencyYears;
        public string ServicePackage;

        public Citizen(string name, int age, double income, int residencyYears)
        {
            Name = name;
            Age = age;
            Income = income;
            ResidencyYears = residencyYears;
        }

        public void Display()
        {
            Console.WriteLine("\n===== Citizen Information =====");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"Income: {Income}");
            Console.WriteLine($"Residency Years: {ResidencyYears}");
            Console.WriteLine($"Service Package: {ServicePackage}");
        }
    }
}
