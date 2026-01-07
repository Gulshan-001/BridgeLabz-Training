using System;
using System.Collections.Generic;

namespace EmployeeWageProblem
{
    // Handles actual employee logic
    public class EmployeeUtilityImpl : IEmployee
    {
        private List<Employee> employees = new List<Employee>();
        private Random random = new Random();

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

                Console.WriteLine(emp.Name +
                    (emp.IsPresent ? " is PRESENT" : " is ABSENT"));
            }
            Console.WriteLine();
        }
    }
}
