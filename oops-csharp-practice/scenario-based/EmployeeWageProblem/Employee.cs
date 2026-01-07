using System;

namespace EmployeeWageProblem
{
    // Holds basic employee info
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsPresent { get; set; }
        //V3
        public bool IsPartTime { get; set; }

        //V5
        public int MonthlyWage { get; set; }


        // NEW: stores calculated daily wage
        public int DailyWage { get; set; }

        public Employee(int id, string name)
        {
            Id = id;
            Name = name;
            IsPresent = false;
            DailyWage = 0;
            IsPartTime = false;
            MonthlyWage = 0;

        }
    }
}
