using System;

public class RankUtility : IRankSystem
{
    public class Student
    {
        public int RollNo;
        public string Name;
        public int Marks;
    }

    private Student[] students;
    private int count;

    public RankUtility(int size)
    {
        students = new Student[size];
        count = 0;
    }

    public void AddStudent()
    {
        if (count >= students.Length)
        {
            Console.WriteLine("Student limit reached.\n");
            return;
        }

        Console.Write("Enter Roll No: ");
        int roll = int.Parse(Console.ReadLine());

        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Marks: ");
        int marks = int.Parse(Console.ReadLine());

        students[count++] = new Student
        {
            RollNo = roll,
            Name = name,
            Marks = marks
        };

        Console.WriteLine("Student added.\n");
    }

    public void SortByMarks()
    {
        // Sorting responsibility given to MergeSort class
        MergeSort.Sort(students, count);
        Console.WriteLine("Sorted using Merge Sort.\n");
    }

    public void DisplayRankList()
    {
        Console.WriteLine("Rank List:");
        Console.WriteLine("----------");

        for (int i = 0; i < count; i++)
        {
            Console.WriteLine(
                $"{i + 1}. {students[i].RollNo} - {students[i].Name} - {students[i].Marks}"
            );
        }

        Console.WriteLine();
    }
}
