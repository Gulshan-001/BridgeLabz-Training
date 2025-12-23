using System;

class Grading2
{
    static void Main(string[] args)
    {
        Console.Write("Enter number of students: ");
        int numberOfStudents = Convert.ToInt32(Console.ReadLine());

        // 2D array to store marks: [student][subject]
        // subject index -> 0: Physics, 1: Chemistry, 2: Maths
        double[,] marks = new double[numberOfStudents, 3];

        double[] percentages = new double[numberOfStudents];
        string[] grades = new string[numberOfStudents];

        // Taking input for marks
        for (int i = 0; i < numberOfStudents; i++)
        {
            Console.WriteLine("\nEnter marks for Student " + (i + 1));

            Console.Write("Physics: ");
            double physics = Convert.ToDouble(Console.ReadLine());

            Console.Write("Chemistry: ");
            double chemistry = Convert.ToDouble(Console.ReadLine());

            Console.Write("Maths: ");
            double maths = Convert.ToDouble(Console.ReadLine());

            // Check for invalid marks
            if (physics < 0 || chemistry < 0 || maths < 0)
            {
                Console.WriteLine("Invalid marks. Please enter positive values.");
                i--;
                continue;
            }

            marks[i, 0] = physics;
            marks[i, 1] = chemistry;
            marks[i, 2] = maths;

            double total = marks[i, 0] + marks[i, 1] + marks[i, 2];
            percentages[i] = (total / 300) * 100;

            // Assign grade based on percentage
            if (percentages[i] >= 80)
                grades[i] = "A";
            else if (percentages[i] >= 70)
                grades[i] = "B";
            else if (percentages[i] >= 60)
                grades[i] = "C";
            else if (percentages[i] >= 50)
                grades[i] = "D";
            else if (percentages[i] >= 40)
                grades[i] = "E";
            else
                grades[i] = "R";
        }

        // Display results
        Console.WriteLine("\n--- Student Results ---");
        for (int i = 0; i < numberOfStudents; i++)
        {
            Console.WriteLine("\nStudent " + (i + 1));
            Console.WriteLine("Physics: " + marks[i, 0]);
            Console.WriteLine("Chemistry: " + marks[i, 1]);
            Console.WriteLine("Maths: " + marks[i, 2]);
            Console.WriteLine("Percentage: " + percentages[i].ToString("0.00") + "%");
            Console.WriteLine("Grade: " + grades[i]);
        }
    }
}
