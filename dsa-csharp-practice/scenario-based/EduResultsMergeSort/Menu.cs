using System;

public class Menu
{
    private RankUtility district1 = new RankUtility(20);
    private RankUtility district2 = new RankUtility(20);

    public void Show()
    {
        int choice;

        do
        {
            Console.WriteLine("=== EduResults Rank System ===");
            Console.WriteLine("1. Add Student to District 1");
            Console.WriteLine("2. Add Student to District 2");
            Console.WriteLine("3. Sort Districts");
            Console.WriteLine("4. Display Districts");
            Console.WriteLine("5. Generate State Rank List");
            Console.WriteLine("6. Exit");
            Console.Write("Choice: ");

            choice = int.Parse(Console.ReadLine());
            Console.WriteLine();

            switch (choice)
            {
                case 1: district1.AddStudent(); break;
                case 2: district2.AddStudent(); break;
                case 3:
                    district1.SortDistrict();
                    district2.SortDistrict();
                    break;
                case 4:
                    district1.DisplayDistrict();
                    district2.DisplayDistrict();
                    break;
                case 5:
                    GenerateStateRank();
                    break;
                case 6:
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Invalid choice.\n");
                    break;
            }

        } while (choice != 6);
    }

    private void GenerateStateRank()
    {
        RankUtility.Student[] stateRank =
            MergeSort.MergeDistricts(
                district1.GetStudents(), district1.GetCount(),
                district2.GetStudents(), district2.GetCount()
            );

        Console.WriteLine("STATE WISE RANK LIST");
        Console.WriteLine("-------------------");

        for (int i = 0; i < stateRank.Length; i++)
        {
            Console.WriteLine(
                $"{i + 1}. {stateRank[i].RollNo} - {stateRank[i].Name} - {stateRank[i].Marks}"
            );
        }

        Console.WriteLine();
    }
}
