using System;
class Arithmetic{
    static void Main()
    {
        int a=Console.ReadLine("Enter first number: ");
        int b=Console.ReadLine("Enter second number: ");
        int sum=a+b;
        int diff=a-b;
        int product=a*b;
        double quotient=(double)a/b;
        Console.WriteLine("The additon, subtraction, multiplication and division of 2 numbers"+ a +" and "+ b +" is " + sum + ", " + diff + ", " + product + " and " + quotient);
        
    }
}