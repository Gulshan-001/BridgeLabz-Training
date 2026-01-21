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
            Console.WriteLine("District student limit reached.\n");
            return;
        }

        Console.Write("Roll No: ");
        int roll = int.Parse(Console.ReadLine());

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Marks: ");
        int marks = int.Parse(Console.ReadLine());

        students[count++] = new Student
        {
            RollNo = roll,
            Name = name,
            Marks = marks
        };

        Console.WriteLine("Student added to district.\n");
    }

    public void SortDistrict()
    {
        // District submits a sorted list
        MergeSort.Sort(students, count);
        Console.WriteLine("District list sorted.\n");
    }

    public void DisplayDistrict()
    {
        Console.WriteLine("District Student List:");
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine(
                $"{i + 1}. {students[i].RollNo} - {students[i].Name} - {students[i].Marks}"
            );
        }
        Console.WriteLine();
    }

    public Student[] GetStudents()
    {
        return students;
    }

    public int GetCount()
    {
        return count;
    }
}
