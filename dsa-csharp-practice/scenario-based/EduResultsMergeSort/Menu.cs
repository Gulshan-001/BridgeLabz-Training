using System;

public class Menu
{
    private IRankSystem system;

    public Menu(IRankSystem system)
    {
        this.system = system;
    }

    public void Show()
    {
        int choice;

        do
        {
            Console.WriteLine("=== EduResults Rank System ===");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Sort by Marks");
            Console.WriteLine("3. Display Rank List");
            Console.WriteLine("4. Exit");
            Console.Write("Choice: ");

            choice = int.Parse(Console.ReadLine());
            Console.WriteLine();

            switch (choice)
            {
                case 1: system.AddStudent(); break;
                case 2: system.SortByMarks(); break;
                case 3: system.DisplayRankList(); break;
                case 4: Console.WriteLine("Bye."); break;
                default: Console.WriteLine("Invalid choice.\n"); break;
            }

        } while (choice != 4);
    }
}
