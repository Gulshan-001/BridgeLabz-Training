using System;

class HandShake
{
    static void Main()
    {
        Console.Write("Enter number of students: ");
        int numberOfStudents = int.Parse(Console.ReadLine());

        int n = (numberOfStudents * (numberOfStudents - 1)) / 2;

        Console.WriteLine(
            "The total number of handshakes if " + numberOfStudents +
            " students shake hand with each other is " + n
        );
    }
}
