using System;

class LuckyDraw
{
    // Check if the visitor wins a gift
    public void CheckNumber(int number)
    {
        if (number % 3 == 0 && number % 5 == 0)
        {
            Console.WriteLine("🎁 Congrats! You won a gift!");
        }
        else
        {
            Console.WriteLine("Sorry, no gift this time.");
        }
    }
}

class Program
{
    static void Main()
    {
        LuckyDraw draw = new LuckyDraw();

        // Loop for multiple visitors
        while (true)
        {
            Console.Write("Enter your lucky number (or -1 to exit): ");
            string input = Console.ReadLine();

            // Invalid input check
            if (!int.TryParse(input, out int number))
            {
                Console.WriteLine("Invalid input. Try again.");
                continue;
            }

            // Exit condition
            if (number == -1)
            {
                break;
            }

            draw.CheckNumber(number);
        }

        Console.WriteLine("Lucky draw ended. Happy Diwali!");
    }
}
