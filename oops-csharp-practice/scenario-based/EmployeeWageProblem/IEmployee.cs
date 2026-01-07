namespace EmployeeWageProblem
{
    public interface IEmployee
    {
        //version1
        void AddEmployee();
        void CheckEmployeeAttendance();

        // NEW FEATURE (version2)
        void CalculateDailyWage();

        //Version3
        void SetPartTimeEmployee();

        //Version5
        void CalculateMonthlyWage();


    }
}
