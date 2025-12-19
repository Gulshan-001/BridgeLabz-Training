using System;
class TotalSalary
{
    static void Main()
    {
        Console.WriteLine("Enter salary");
        double salary = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter bonus");
        double bonus = Convert.ToDouble(Console.ReadLine());
        double totalSalary = salary + bonus;    
        Console.WriteLine("The salary is INR" + salary + " and bonus is INR" + bonus + ". Hence Total Salary is INR" + totalSalary);
    }
}