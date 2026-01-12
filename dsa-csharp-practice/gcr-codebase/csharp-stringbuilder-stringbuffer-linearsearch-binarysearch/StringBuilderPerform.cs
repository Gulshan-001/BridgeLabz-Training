using System;
using System.Text;
using System.Diagnostics;

class StringBuilderPerform
{
    static void Main()
    {
        int iterations = 100000;

        // 1️⃣ Using String concatenation (+)
        Stopwatch sw1 = new Stopwatch();
        sw1.Start();

        string normalString = "";
        for (int i = 0; i < iterations; i++)
        {
            normalString += "a";
        }

        sw1.Stop();
        Console.WriteLine("String (+) Time: " + sw1.ElapsedMilliseconds + " ms");

        // 2️⃣ Using StringBuilder
        Stopwatch sw2 = new Stopwatch();
        sw2.Start();

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < iterations; i++)
        {
            sb.Append("a");
        }

        sw2.Stop();
        Console.WriteLine("StringBuilder Time: " + sw2.ElapsedMilliseconds + " ms");
    }
}
