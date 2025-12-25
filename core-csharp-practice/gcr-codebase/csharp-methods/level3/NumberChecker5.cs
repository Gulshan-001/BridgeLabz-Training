using System;

namespace CSharpPractice
{
    class NumberChecker5
    {
        // a. Find factors of a number
        public static int[] GetFactors(int num)
        {
            int count = 0;
            for (int i = 1; i <= num; i++)
            {
                if (num % i == 0) count++;
            }

            int[] factors = new int[count];
            int index = 0;
            for (int i = 1; i <= num; i++)
            {
                if (num % i == 0)
                {
                    factors[index] = i;
                    index++;
                }
            }
            return factors;
        }

        // b. Find greatest factor
        public static int GreatestFactor(int num)
        {
            int[] factors = GetFactors(num);
            return factors[factors.Length - 1]; // last factor is greatest
        }

        // c. Sum of factors
        public static int SumOfFactors(int num)
        {
            int[] factors = GetFactors(num);
            int sum = 0;
            foreach (int f in factors) sum += f;
            return sum;
        }

        // d. Product of factors
        public static long ProductOfFactors(int num)
        {
            int[] factors = GetFactors(num);
            long product = 1;
            foreach (int f in factors) product *= f;
            return product;
        }

        // e. Product of cube of factors
        public static double ProductOfCubesOfFactors(int num)
        {
            int[] factors = GetFactors(num);
            double product = 1;
            foreach (int f in factors) product *= Math.Pow(f, 3);
            return product;
        }

        // f. Check perfect number
        public static bool IsPerfect(int num)
        {
            int sum = 0;
            for (int i = 1; i < num; i++)
            {
                if (num % i == 0) sum += i;
            }
            return sum == num;
        }

        // g. Check abundant number
        public static bool IsAbundant(int num)
        {
            int sum = 0;
            for (int i = 1; i < num; i++)
            {
                if (num % i == 0) sum += i;
            }
            return sum > num;
        }

        // h. Check deficient number
        public static bool IsDeficient(int num)
        {
            int sum = 0;
            for (int i = 1; i < num; i++)
            {
                if (num % i == 0) sum += i;
            }
            return sum < num;
        }

        // Helper method for factorial
        public static int Factorial(int n)
        {
            int fact = 1;
            for (int i = 2; i <= n; i++) fact *= i;
            return fact;
        }

        // i. Check strong number
        public static bool IsStrong(int num)
        {
            int n = num;
            int sum = 0;
            while (n > 0)
            {
                int digit = n % 10;
                sum += Factorial(digit);
                n /= 10;
            }
            return sum == num;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            int num = int.Parse(Console.ReadLine());

            int[] factors = NumberChecker.GetFactors(num);
            Console.WriteLine("Factors: " + string.Join(", ", factors));
            Console.WriteLine("Greatest factor: " + NumberChecker.GreatestFactor(num));
            Console.WriteLine("Sum of factors: " + NumberChecker.SumOfFactors(num));
            Console.WriteLine("Product of factors: " + NumberChecker.ProductOfFactors(num));
            Console.WriteLine("Product of cubes of factors: " + NumberChecker.ProductOfCubesOfFactors(num));
            Console.WriteLine("Perfect number? " + (NumberChecker.IsPerfect(num) ? "Yes" : "No"));
            Console.WriteLine("Abundant number? " + (NumberChecker.IsAbundant(num) ? "Yes" : "No"));
            Console.WriteLine("Deficient number? " + (NumberChecker.IsDeficient(num) ? "Yes" : "No"));
            Console.WriteLine("Strong number? " + (NumberChecker.IsStrong(num) ? "Yes" : "No"));
        }
    }
}
