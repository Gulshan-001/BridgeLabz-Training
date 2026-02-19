using System;

namespace TechVille_Phase2.Models
{
    public class Citizen
    {
        private string name;
        private int age;
        private double income;

        public string Name => name;
        public int Age => age;
        public double Income => income;

        public Citizen(string name, int age, double income)
        {
            this.name = name;
            this.age = age;
            this.income = income;
        }

        public override string ToString()
        {
            return $"Citizen: {name}, Age: {age}, Income: {income}";
        }
    }
}
