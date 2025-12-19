using System;

class Operators
{
    static void Main()
    {
        
        // Arithmetic Operators
        
        Console.WriteLine("Arithmetic Operators Demo");
        int firstNumber = 12;
        int secondNumber = 4;

        Console.WriteLine("Sum: " + (firstNumber + secondNumber));
        Console.WriteLine("Difference: " + (firstNumber - secondNumber));
        Console.WriteLine("Product: " + (firstNumber * secondNumber));
        Console.WriteLine("Quotient: " + (firstNumber / secondNumber));
        Console.WriteLine("Remainder: " + (firstNumber % secondNumber));

        
        // Relational Operators
       
        Console.WriteLine("\nRelational Operators Demo");
        Console.WriteLine("firstNumber > secondNumber : " + (firstNumber > secondNumber));
        Console.WriteLine("firstNumber < secondNumber : " + (firstNumber < secondNumber));
        Console.WriteLine("firstNumber == secondNumber : " + (firstNumber == secondNumber));
        Console.WriteLine("firstNumber != secondNumber : " + (firstNumber != secondNumber));

        
        // Assignment Operators
        
        Console.WriteLine("\nAssignment Operators Demo");
        int total = 20;

        total += 10;   // total = total + 10
        Console.WriteLine("After += operation: " + total);

        total -= 5;    // total = total - 5
        Console.WriteLine("After -= operation: " + total);

       
        // Unary Operators
       
        Console.WriteLine("\nUnary Operators Demo");
        int counter = 7;

        Console.WriteLine("Post Increment (counter++): " + (counter++));
        Console.WriteLine("Pre Increment (++counter): " + (++counter));

        
        // Ternary Operator
       
        Console.WriteLine("\nTernary Operator Demo");
        int value = 15;
        string checkResult = (value % 2 == 0) ? "Even" : "Odd";
        Console.WriteLine("The number is: " + checkResult);

       
        // Bitwise Operators

        Console.WriteLine("\nBitwise Operators Demo");
        int bitA = 6;
        int bitB = 2;

        Console.WriteLine("bitA & bitB : " + (bitA & bitB));
        Console.WriteLine("bitA | bitB : " + (bitA | bitB));
        Console.WriteLine("bitA ^ bitB : " + (bitA ^ bitB));

        
        // is Operator
        
        Console.WriteLine("\nIs Operator Demo");
        object language = "C# Programming";
        Console.WriteLine("Is language a string? " + (language is string));

        Console.WriteLine("\nProgram executed successfully");
    }
}
