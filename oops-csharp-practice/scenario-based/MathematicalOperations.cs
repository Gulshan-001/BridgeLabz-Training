using System;

class MathematicalOperations
{
    public int Num1, Num2;

    public MathematicalOperations(int num1, int num2)
    {
        this.Num1 = num1;
        this.Num2 = num2;
    }

    public int factorial(int Num1)
    {
        if (Num1 < 0)
            return -1;

        if (Num1 == 0 || Num1 == 1)
            return 1;

        return Num1 * factorial(Num1 - 1);
    }

    public bool primeCheck(int Num1)
    {
        if (Num1 <= 1)
            return false;

        for (int i = 2; i <= Num1 / 2; i++)
        {
            if (Num1 % i == 0)
                return false;
        }
        return true;
    }

    public int gcd(int Num1, int Num2)
    {
        Num1 = Math.Abs(Num1);
        Num2 = Math.Abs(Num2);

        while (Num2 != 0)
        {
            int remainder = Num1 % Num2;
            Num1 = Num2;
            Num2 = remainder;
        }
        return Num1;
    }

    public int fibonacci(int n)
    {
        if (n < 0)
            return -1;

        if (n == 0) return 0;
        if (n == 1) return 1;

        int a = 0, b = 1, c = 0;
        for (int i = 2; i <= n; i++)
        {
            c = a + b;
            a = b;
            b = c;
        }
        return c;
    }
}

class Program
{
    static void Main(string[] args)
    {
        MathematicalOperations obj = new MathematicalOperations(12, 18);

        Console.WriteLine("Factorial of 5: " + obj.factorial(5));
        Console.WriteLine("Factorial of 0: " + obj.factorial(0));
        Console.WriteLine("Factorial of -3: " + obj.factorial(-3));

        Console.WriteLine("Is 7 Prime? " + obj.primeCheck(7));
        Console.WriteLine("Is 1 Prime? " + obj.primeCheck(1));
        Console.WriteLine("Is -5 Prime? " + obj.primeCheck(-5));

        Console.WriteLine("GCD of 12 and 18: " + obj.gcd(12, 18));
        Console.WriteLine("GCD of 0 and 10: " + obj.gcd(0, 10));

        Console.WriteLine("Fibonacci of 0: " + obj.fibonacci(0));
        Console.WriteLine("Fibonacci of 1: " + obj.fibonacci(1));
        Console.WriteLine("Fibonacci of 7: " + obj.fibonacci(7));
        Console.WriteLine("Fibonacci of -4: " + obj.fibonacci(-4));
    }
}
