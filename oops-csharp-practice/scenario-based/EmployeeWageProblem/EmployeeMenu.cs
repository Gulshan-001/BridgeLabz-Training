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
                Console.WriteLine("3. Mark Employee as Part-Time");
                Console.WriteLine("4. Calculate Daily Wage");
                Console.WriteLine("5. Calculate Monthly Wage");
                Console.WriteLine("6. Calculate Monthly Wage (With Condition)");
                Console.WriteLine("7. Exit");

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
                        employeeUtility.SetPartTimeEmployee();
                        break;
                    case 4:
                        employeeUtility.CalculateDailyWage();
                        break;
                    case 5:
                        employeeUtility.CalculateMonthlyWage();
                        break;
                    case 6:
                        employeeUtility.CalculateMonthlyWageWithCondition();
                        break;
                    case 7:
                        return;

                    default:
                        Console.WriteLine("Invalid choice\n");
                        break;
                }
            }
        }
    }
}
