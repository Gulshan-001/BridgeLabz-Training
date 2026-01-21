using System;

public class Menu
{
    private ICheckoutSystem system;

    public Menu(ICheckoutSystem system)
    {
        this.system = system;
    }

    public void Show()
    {
        int choice;

        do
        {
            Console.WriteLine("=== SmartCheckout System ===");
            Console.WriteLine("1. Add Customer");
            Console.WriteLine("2. Serve Customer");
            Console.WriteLine("3. Show Queue");
            Console.WriteLine("4. Exit");
            Console.Write("Choice: ");

            choice = int.Parse(Console.ReadLine());
            Console.WriteLine();

            switch (choice)
            {
                case 1: system.AddCustomer(); break;
                case 2: system.ServeCustomer(); break;
                case 3: system.ShowQueue(); break;
                case 4: Console.WriteLine("Exiting..."); break;
                default: Console.WriteLine("Invalid choice.\n"); break;
            }

        } while (choice != 4);
    }
}
