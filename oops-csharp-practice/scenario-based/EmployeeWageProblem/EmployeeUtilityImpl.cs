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
//------------------------------VERSION 2   -----------------------------       
        public void CalculateDailyWage()
        {
            if (employees.Count == 0)
            {
                Console.WriteLine("No employees found\n");
                return;
            }

            foreach (Employee emp in employees)
            {
                if (emp.IsPresent)
                {
                    if (emp.IsPartTime)
                        emp.DailyWage = WAGE_PER_HOUR * PART_TIME_HOURS;
                    else
                        emp.DailyWage = WAGE_PER_HOUR * FULL_DAY_HOURS;
                }
                else
                {
                    emp.DailyWage = 0;
                }

                Console.WriteLine(
                    emp.Name + " => Daily Wage: ₹" + emp.DailyWage
                );
            }

            Console.WriteLine();
        }
    }
}
