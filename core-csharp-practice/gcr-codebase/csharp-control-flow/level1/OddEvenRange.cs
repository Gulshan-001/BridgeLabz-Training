using System;

class OddEvenRange
{
    static void Main()
    {
        Console.WriteLine("Enter a natural number:");
        int number = Convert.ToInt32(Console.ReadLine());

        if (number <= 0)
        {
            Console.WriteLine("Please enter a natural number greater than 0.");
        }
        else
        {
            for (int i = 1; i <= number; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i + " is an Even number");
                }
                else
                {
                    Console.WriteLine(i + " is an Odd number");
                }
            }
        }
    }
}
