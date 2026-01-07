namespace EmployeeWageProblem
{
    // Starts the employee system
    public class EmployeeMain
    {
        public static void Start()
        {
            IEmployee utility = new EmployeeUtilityImpl();
            new EmployeeMenu(utility).ShowMenu();
        }
    }
}
