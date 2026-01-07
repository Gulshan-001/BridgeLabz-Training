using System;

namespace EmployeeWageProblem
{
    // Holds basic employee info
    public class Employee
    {
        public int Id { get; set; }        // employee id
        public string Name { get; set; }   // employee name
        public bool IsPresent { get; set; }// attendance status

        public Employee(int id, string name)
        {
            Id = id;
            Name = name;
            IsPresent = false; // default = absent
        }
    }
}
