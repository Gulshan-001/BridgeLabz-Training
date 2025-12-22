using System;

class HarshadNumber
{
    static void Main(string[] args)
    {
        int number = Convert.ToInt32(Console.ReadLine());
        int sum = 0;
        int tempNumber = Math.Abs(number);

        while (tempNumber != 0)
        {
            sum += tempNumber % 10;
            tempNumber /= 10;
        }

        if (number % sum == 0)
            Console.WriteLine(number + " is a Harshad Number");
        else
            Console.WriteLine(number + " is not a Harshad Number");
    }
}
