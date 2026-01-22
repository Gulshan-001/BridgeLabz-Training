using System;

public class Menu
{
    private IHospitalRoute route;

    public Menu(IHospitalRoute route)
    {
        this.route = route;
    }

    public void Show()
    {
        int choice;

        do
        {
            Console.WriteLine("\n=== Ambulance Route System ===");
            Console.WriteLine("1. Add Hospital Unit");
            Console.WriteLine("2. Remove Unit (Maintenance)");
            Console.WriteLine("3. Redirect Patient");
            Console.WriteLine("4. Display Route");
            Console.WriteLine("5. Exit");
            Console.Write("Enter choice: ");

            choice = int.Parse(Console.ReadLine());
            Console.WriteLine();

            switch (choice)
            {
                case 1:
                    Console.Write("Enter unit name: ");
                    route.AddUnit(Console.ReadLine());
                    break;

                case 2:
                    Console.Write("Enter unit to remove: ");
                    route.RemoveUnit(Console.ReadLine());
                    break;

                case 3:
                    route.RedirectPatient();
                    break;

                case 4:
                    route.DisplayRoute();
                    break;

                case 5:
                    Console.WriteLine("System shutting down...");
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

        } while (choice != 5);
    }
}
