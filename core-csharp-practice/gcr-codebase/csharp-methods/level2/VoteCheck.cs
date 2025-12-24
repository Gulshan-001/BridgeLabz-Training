using System;

class VoteCheck
{
    // method to check whether a student can vote based on age
    public static bool CanStudentVote(int age)
    {
        if (age < 0)
            return false;

        if (age >= 18)
            return true;

        return false;
    }

    static void Main(string[] args)
    {
        int[] ages = new int[10];

        // take ages of 10 students from user
        for (int i = 0; i < ages.Length; i++)
        {
            Console.Write("Enter age of student " + (i + 1) + ": ");
            ages[i] = Convert.ToInt32(Console.ReadLine());

            bool canVote = CanStudentVote(ages[i]);

            if (canVote)
                Console.WriteLine("Student " + (i + 1) + " can vote.");
            else
                Console.WriteLine("Student " + (i + 1) + " cannot vote.");
        }
    }
}
