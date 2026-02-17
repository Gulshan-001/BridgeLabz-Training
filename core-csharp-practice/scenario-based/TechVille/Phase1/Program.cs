using System;

namespace TechVille_Phase1
{
    class Program
    {
        static void Main(string[] args)
        {
            RegistrationManager manager = new RegistrationManager();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n===== TECHVILLE SMART CITY =====");
                Console.WriteLine("1. Register Citizen");
                Console.WriteLine("2. Exit");
                Console.Write("Choose Option: ");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        manager.RegisterCitizen();
                        break;
                    case 2:
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}
