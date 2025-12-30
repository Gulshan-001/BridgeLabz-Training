using System;

class StudentResult
{
    static void Main()
    {
        int studentCount;

        // Keep asking until a valid student count is entered
        while (true)
        {
            try
            {
                Console.Write("Enter number of students: ");
                studentCount = int.Parse(Console.ReadLine());

                if (studentCount <= 0)
                {
                    Console.WriteLine("Student count should be more than zero.");
                    continue;
                }
                break;
            }
            catch
            {
                Console.WriteLine("Invalid input. Please enter a proper number.");
            }
        }

        int[] marks = new int[studentCount];
        int total = 0;

        // Take marks for each student with validation
        for (int i = 0; i < studentCount; i++)
        {
            while (true)
            {
                try
                {
                    Console.Write($"Enter score of student {i + 1}: ");
                    int value = int.Parse(Console.ReadLine());

                    if (value < 0)
                    {
                        Console.WriteLine("Marks cannot be negative.");
                        continue;
                    }

                    marks[i] = value;
                    total += value;
                    break;
                }
                catch
                {
                    Console.WriteLine("Invalid input. Numbers only.");
                }
            }
        }

        // Compute average score
        double avgScore = (double)total / studentCount;

        // Initialize highest and lowest using first element
        int maxScore = marks[0];
        int minScore = marks[0];

        // Find highest and lowest marks
        for (int i = 1; i < studentCount; i++)
        {
            if (marks[i] > maxScore)
                maxScore = marks[i];

            if (marks[i] < minScore)
                minScore = marks[i];
        }

        // Display final results
        Console.WriteLine("\n--- Result ---");
        Console.WriteLine($"Average Score: {avgScore}");
        Console.WriteLine($"Highest Score: {maxScore}");
        Console.WriteLine($"Lowest Score: {minScore}");

        // Print all scores that are above average
        Console.WriteLine("\nScores above average:");
        for (int i = 0; i < studentCount; i++)
        {
            if (marks[i] > avgScore)
                Console.WriteLine(marks[i]);
        }
    }
}
