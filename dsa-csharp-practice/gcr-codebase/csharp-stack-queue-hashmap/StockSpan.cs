using System;
using System.Collections.Generic;

class StockSpan
{
    static void CalculateSpan(int[] prices)
    {
        int n = prices.Length;
        int[] span = new int[n];
        Stack<int> stack = new Stack<int>(); // stores indices

        for (int i = 0; i < n; i++)
        {
            // Pop while current price is higher or equal
            while (stack.Count > 0 && prices[stack.Peek()] <= prices[i])
            {
                stack.Pop();
            }

            // Calculate span
            span[i] = (stack.Count == 0) ? (i + 1) : (i - stack.Peek());

            // Push current index
            stack.Push(i);
        }

        // Print result
        Console.WriteLine("Stock Prices:");
        foreach (int price in prices)
            Console.Write(price + " ");

        Console.WriteLine("\nSpan Values:");
        foreach (int s in span)
            Console.Write(s + " ");
    }

    static void Main()
    {
        int[] prices = { 100, 80, 60, 70, 60, 75, 85 };
        CalculateSpan(prices);
    }
}
