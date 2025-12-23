using System;

class Grading
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter number of students:");
        int n = Convert.ToInt32(Console.ReadLine());

        double[,] marks = new double[n, 3];   // physics, chemistry, maths
        double[] percentage = new double[n];
        string[] grade = new string[n];

        // Taking input for each student
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("\nStudent " + (i + 1));

            Console.Write("Physics marks: ");
            double physics = Convert.ToDouble(Console.ReadLine());

            Console.Write("Chemistry marks: ");
            double chemistry = Convert.ToDouble(Console.ReadLine());

            Console.Write("Maths marks: ");
            double maths = Convert.ToDouble(Console.ReadLine());

            // If any mark is invalid, redo this student
            if (physics < 0 || chemistry < 0 || maths < 0)
            {
                Console.WriteLine("Invalid marks entered. Please enter positive values.");
                i--;
                continue;
            }

            marks[i, 0] = physics;
            marks[i, 1] = chemistry;
            marks[i, 2] = maths;

            double total = physics + chemistry + maths;
            percentage[i] = (total / 300) * 100;

            // Decide grade
            if (percentage[i] >= 80)
                grade[i] = "A";
            else if (percentage[i] >= 70)
                grade[i] = "B";
            else if (percentage[i] >= 60)
                grade[i] = "C";
            else if (percentage[i] >= 50)
                grade[i] = "D";
            else if (percentage[i] >= 40)
                grade[i] = "E";
            else
                grade[i] = "R";
        }

        // Displaying results
        Console.WriteLine("\n--- Student Results ---");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("\nStudent " + (i + 1));
            Console.WriteLine("Physics: " + marks[i, 0]);
            Console.WriteLine("Chemistry: " + marks[i, 1]);
            Console.WriteLine("Maths: " + marks[i, 2]);
            Console.WriteLine("Percentage: " + percentage[i].ToString("0.00") + "%");
            Console.WriteLine("Grade: " + grade[i]);
        }
    }
}
