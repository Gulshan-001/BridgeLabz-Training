using System;

class EmployeeBonus
{
    static void Main(string[] args)
    {
        // Arrays to store salary and years of service
        double[] salary = new double[10];
        double[] yearsOfService = new double[10];

        // Arrays to store bonus amount and new salary
        double[] bonus = new double[10];
        double[] newSalary = new double[10];

        double totalBonus = 0.0;
        double totalOldSalary = 0.0;
        double totalNewSalary = 0.0;

        Console.WriteLine("Enter salary and years of service for 10 employees:");

        // Taking input from user
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("Employee " + (i + 1));

            Console.Write("Enter salary: ");
            salary[i] = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter years of service: ");
            yearsOfService[i] = Convert.ToDouble(Console.ReadLine());

            // If invalid input, ask again
            if (salary[i] <= 0 || yearsOfService[i] < 0)
            {
                Console.WriteLine("Invalid input. Please enter again.");
                i--;
                continue;
            }
        }

        // Calculating bonus and new salary
        for (int i = 0; i < 10; i++)
        {
            if (yearsOfService[i] > 5)
            {
                bonus[i] = salary[i] * 0.05;
            }
            else
            {
                bonus[i] = salary[i] * 0.02;
            }

            newSalary[i] = salary[i] + bonus[i];

            totalBonus += bonus[i];
            totalOldSalary += salary[i];
            totalNewSalary += newSalary[i];
        }

        Console.WriteLine();
        Console.WriteLine("Total Old Salary: " + totalOldSalary);
        Console.WriteLine("Total Bonus Paid: " + totalBonus);
        Console.WriteLine("Total New Salary: " + totalNewSalary);
    }
}
