using System;
using System.Runtime.CompilerServices;
public class SmallestOfThree
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter first number:");
        int number1 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter second number:");
        int number2 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter third number:");
        int number3 = Convert.ToInt32(Console.ReadLine());
        if(number1<number2 && number1 < number3)
        {
            Console.WriteLine("Is the first number the smallest? True");
        }
        else
        {
            Console.WriteLine("Is the first number the smallest? False");
        }
        
        }

        
    }
