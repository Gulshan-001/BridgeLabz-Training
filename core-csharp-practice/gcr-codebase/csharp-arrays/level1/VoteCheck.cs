using System;

class VoteCheck
{
    static void Main(string[] args)
    {
        // Create an array to store the ages of 10 students
        int[] ages = new int[10];

        // Ask the user to enter the ages
        Console.WriteLine("Enter the age of 10 students:");

        // This loop is used to take input for all 10 students
        for (int i = 0; i < ages.Length; i++)
        {
            // Asking age for each student one by one
            Console.Write("Enter age of student " + (i + 1) + ": ");
            ages[i] = Convert.ToInt32(Console.ReadLine());
        }

        Console.WriteLine();
        Console.WriteLine("Checking voting eligibility:");
        Console.WriteLine();

        // This loop checks each student's age and decides voting eligibility
        for (int i = 0; i < ages.Length; i++)
        {
            // If age is negative, it is not valid
            if (ages[i] < 0)
            {
                Console.WriteLine("Invalid age entered: " + ages[i]);
            }
            // If age is 18 or more, student can vote
            else if (ages[i] >= 18)
            {
                Console.WriteLine("The student with the age " + ages[i] + " can vote.");
            }
            // If age is less than 18, student cannot vote
            else
            {
                Console.WriteLine("The student with the age " + ages[i] + " cannot vote.");
            }
        }
    }
}
