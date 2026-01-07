using System;
using System.Collections.Generic;

namespace EmployeeWageProblem
{
    // Handles actual employee logic
    public class EmployeeUtilityImpl : IEmployee
    {
        private List<Employee> employees = new List<Employee>();
        private Random random = new Random();

        private const int WAGE_PER_HOUR = 20;
        private const int FULL_DAY_HOURS = 8;
        private const int PART_TIME_HOURS = 8;
        private const int WORKING_DAYS_PER_MONTH = 20;
        private const int MAX_WORKING_DAYS = 20;
        private const int MAX_WORKING_HOURS = 100;



        public void AddEmployee()
        {
            Console.Write("Enter Employee ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Employee Name: ");
            string name = Console.ReadLine();

            employees.Add(new Employee(id, name));
            Console.WriteLine("Employee added successfully\n");
        }

        public void CheckEmployeeAttendance()
        {
            if (employees.Count == 0)
            {
                Console.WriteLine("No employees found\n");
                return;
            }

            foreach (Employee emp in employees)
            {
                // 0 = absent, 1 = present
                emp.IsPresent = random.Next(0, 2) == 1;

                Console.WriteLine(
                    emp.Name + (emp.IsPresent ? " is PRESENT" : " is ABSENT")
                );
            }

            Console.WriteLine();
        }

//------------------------------VERSION 3-----------------------------
        public void SetPartTimeEmployee()
        {
            if (employees.Count == 0)
            {
                Console.WriteLine("No employees found\n");
                return;
            }

            Console.Write("Enter Employee ID to mark as Part-Time: ");
            int id = Convert.ToInt32(Console.ReadLine());

            foreach (Employee emp in employees)
            {
                if (emp.Id == id)
                {
                    emp.IsPartTime = true;
                    Console.WriteLine(emp.Name + " marked as PART-TIME\n");
                    return;
                }
            }

            Console.WriteLine("Employee not found\n");
        }

//---------------------------VERSION 4 CALCULATE DAILY WAGE USING SWITCH CASE----------------
        public void CalculateDailyWage()
        {
            if (employees.Count == 0)
            {
                Console.WriteLine("No employees found\n");
                return;
            }

            foreach (Employee emp in employees)
            {
                int workType;

                if (!emp.IsPresent)
                    workType = 0;
                else if (emp.IsPartTime)
                    workType = 2;
                else
                    workType = 1;

                switch (workType)
                {
                    case 1: // Full-Time
                        emp.DailyWage = WAGE_PER_HOUR * FULL_DAY_HOURS;
                        break;

                    case 2: // Part-Time
                        emp.DailyWage = WAGE_PER_HOUR * PART_TIME_HOURS;
                        break;

                    default: // Absent
                        emp.DailyWage = 0;
                        break;
                }

                Console.WriteLine(
                    emp.Name + " => Daily Wage: ₹" + emp.DailyWage
                );
            }

            Console.WriteLine();
        }

//---------------------------VERSION 5 CALCULATE MONTHLY WAGE----------------
        public void CalculateMonthlyWage()
        {
            if (employees.Count == 0)
            {
                Console.WriteLine("No employees found\n");
                return;
            }

            foreach (Employee emp in employees)
            {
                emp.MonthlyWage = emp.DailyWage * WORKING_DAYS_PER_MONTH;

                Console.WriteLine(
                    emp.Name + " => Monthly Wage: ₹" + emp.MonthlyWage
                );
            }

            Console.WriteLine();
        }

//---------------------------VERSION 6 CALCULATE MONTHLY WAGE WITH CONDITIONS----------------
public void CalculateMonthlyWageWithCondition()
{
    if (employees.Count == 0)
    {
        Console.WriteLine("No employees found\n");
        return;
    }

    foreach (Employee emp in employees)
    {
        int totalDays = 0;
        int totalHours = 0;
        int totalWage = 0;

        // keep calculating until any condition fails
        while (totalDays < MAX_WORKING_DAYS && totalHours < MAX_WORKING_HOURS)
        {
            int workType = random.Next(0, 3); // 0-Absent, 1-Full, 2-Part
            int hoursWorked = 0;

            switch (workType)
            {
                case 1: // Full-time
                    hoursWorked = FULL_DAY_HOURS;
                    break;

                case 2: // Part-time
                    hoursWorked = PART_TIME_HOURS;
                    break;

                default: // Absent
                    hoursWorked = 0;
                    break;
            }

            totalHours += hoursWorked;
            totalDays++;

            totalWage += hoursWorked * WAGE_PER_HOUR;
        }

        emp.MonthlyWage = totalWage;

        Console.WriteLine(
            emp.Name +
            " => Monthly Wage (with condition): ₹" + emp.MonthlyWage +
            " | Days: " + totalDays +
            " | Hours: " + totalHours
        );
    }

    Console.WriteLine();
} 
    }
}
