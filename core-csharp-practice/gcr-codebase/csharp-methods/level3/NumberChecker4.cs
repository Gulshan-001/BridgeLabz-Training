using System;

namespace CSharpPractice
{
    class NumberChecker
    {
        // a. Check if number is prime
        public static bool IsPrime(int num)
        {
            if (num <= 1) return false;
            for (int i = 2; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0) return false;
            }
            return true;
        }

        // b. Check if number is neon
        public static bool IsNeon(int num)
        {
            int square = num * num;
            int sum = 0;
            while (square > 0)
            {
                sum += square % 10;
                square /= 10;
            }
            return sum == num;
        }

        // c. Check if number is spy
        public static bool IsSpy(int num)
        {
            int sum = 0, product = 1, n = num;
            while (n > 0)
            {
                int digit = n % 10;
                sum += digit;
                product *= digit;
                n /= 10;
            }
            return sum == product;
        }

        // d. Check if number is automorphic
        public static bool IsAutomorphic(int num)
        {
            int square = num * num;
            int n = num;
            while (n > 0)
            {
                if (n % 10 != square % 10)
                    return false;
                n /= 10;
                square /= 10;
            }
            return true;
        }

        // e. Check if number is buzz
        public static bool IsBuzz(int num)
        {
            return num % 7 == 0 || num % 10 == 7;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            int num = int.Parse(Console.ReadLine());

            Console.WriteLine("Prime number? " + (NumberChecker.IsPrime(num) ? "Yes" : "No"));
            Console.WriteLine("Neon number? " + (NumberChecker.IsNeon(num) ? "Yes" : "No"));
            Console.WriteLine("Spy number? " + (NumberChecker.IsSpy(num) ? "Yes" : "No"));
            Console.WriteLine("Automorphic number? " + (NumberChecker.IsAutomorphic(num) ? "Yes" : "No"));
            Console.WriteLine("Buzz number? " + (NumberChecker.IsBuzz(num) ? "Yes" : "No"));
        }
    }
}
