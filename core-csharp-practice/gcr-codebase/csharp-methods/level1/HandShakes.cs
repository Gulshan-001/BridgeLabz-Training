using System;

class Handshakes
{
    // method to calculate handshakes using formula: n * (n-1) / 2
    static int CalculateHandshakes(int n)
    {
        return (n * (n - 1)) / 2;
    }

    static void Main(string[] args)
    {
        // ask user for number of students
        Console.Write("Enter number of students: ");
        int n = Convert.ToInt32(Console.ReadLine());

        // calculate maximum handshakes by calling the method
        int handshakes = CalculateHandshakes(n);

        Console.WriteLine(
            "The maximum number of handshakes among " + n + " students is " + handshakes
        );
    }
}
