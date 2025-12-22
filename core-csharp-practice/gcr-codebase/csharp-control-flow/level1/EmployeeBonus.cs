using System;

class EmployeeBonus
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter employee salary:");
        double salary = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter years of service:");
        int yearsOfService = Convert.ToInt32(Console.ReadLine());

        double bonus = 0;

        if (yearsOfService > 5)
        {
            bonus = salary * 0.05;
            Console.WriteLine("The bonus amount is " + bonus);
        }
        else
        {
            Console.WriteLine("No bonus applicable");
        }
    }
}
