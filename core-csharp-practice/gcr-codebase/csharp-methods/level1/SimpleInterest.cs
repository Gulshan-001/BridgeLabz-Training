using System;

class SimpleInterest
{
    // method to calculate simple interest
    static double CalculateSimpleInterest(double principal, double rate, double time)
    {
        return (principal * rate * time) / 100;
    }

    static void Main(string[] args)
    {
        // taking principal value from user
        Console.Write("Enter Principal: ");
        double principal = Convert.ToDouble(Console.ReadLine());
        
        // taking rate of interest from user
        Console.Write("Enter Rate of Interest: ");
        double rate = Convert.ToDouble(Console.ReadLine());

        // taking time value from user
        Console.Write("Enter Time: ");
        double time = Convert.ToDouble(Console.ReadLine());

        // calling method to calculate simple interest
        double simpleInterest = CalculateSimpleInterest(principal, rate, time);

        // displaying the final output
        Console.WriteLine(
            "The Simple Interest is " + simpleInterest +
            " for Principal " + principal +
            ", Rate of Interest " + rate +
            " and Time " + time
        );
    }
}
