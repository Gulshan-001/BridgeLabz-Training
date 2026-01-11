using System;

class StudentMarks
{
    static void Main()
    {
        // Student marks array
        int[] marks = { 78, 45, 89, 62, 91, 55 };

        int n = marks.Length;

        // Bubble Sort logic
        for (int i = 0; i < n - 1; i++)
        {
            // each pass pushes the largest value to the end
            for (int j = 0; j < n - i - 1; j++)
            {
                // compare adjacent elements
                if (marks[j] > marks[j + 1])
                {
                    // swap
                    int temp = marks[j];
                    marks[j] = marks[j + 1];
                    marks[j + 1] = temp;
                }
            }
        }

        // Display sorted marks
        Console.WriteLine("Student marks in ascending order:");
        foreach (int m in marks)
        {
            Console.Write(m + " ");
        }
    }
}
