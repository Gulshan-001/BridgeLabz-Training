using System;
class HarryAge
{
    static void Main()
    {
        int numberOfStudents=Console.ReadLine("Enter number of students: ");
        int n=(numberOfStudents*(numberOfStudents-1))/2;
        Console.WriteLine("The total number of handshakes if " + numberOfStudents + " students shake hand with each other is " + n);
    }
}