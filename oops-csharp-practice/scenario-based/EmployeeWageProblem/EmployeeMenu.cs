using System;

namespace EmployeeWageProblem
{
    // Displays menu and takes user input
    public class EmployeeMenu
    {
        private IEmployee employeeUtility;

        public EmployeeMenu(IEmployee utility)
        {
            employeeUtility = utility;
        }

        public void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Check Attendance");
                Console.WriteLine("3. Exit");
                Console.Write("Choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        employeeUtility.AddEmployee();
                        break;
                    case 2:
                        employeeUtility.CheckEmployeeAttendance();
                        break;
                    case 3:
                        return;
                    default:
                        Console.WriteLine("Invalid choice\n");
                        break;
                }
            }
        }
    }
}
