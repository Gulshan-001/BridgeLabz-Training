using System;

class OpPrecedence
{
    static void Main()
    {
        Console.WriteLine("Enter a");
        double a = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter b");
        double b = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter c");
        double c = Convert.ToDouble(Console.ReadLine());

        double res1 = a + b * c;
        double res2 = a * b + c;
        double res3 = c + a / b;
        double res4 = a % b + c;

        Console.WriteLine(
            "The result of Double Operations are: " +
            res1 + "," + res2 + "," + res3 + "," + res4
        );
    }
}
