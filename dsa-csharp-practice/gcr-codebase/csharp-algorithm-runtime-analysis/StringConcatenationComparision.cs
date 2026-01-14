using System;
using System.Diagnostics;
using System.Text;

class StringConcatenationComparision
{
    static readonly object lockObj = new object();

    static void Main()
    {
        int[] operations = { 1000, 10000, 1000000 };

        Console.WriteLine("Operations\tString(O(N^2))\tStringBuilder(O(N))\tStringBuffer(O(N))");

        foreach (int n in operations)
        {
            long stringTime = TestString(n);
            long builderTime = TestStringBuilder(n);
            long bufferTime = TestStringBuffer(n);

            Console.WriteLine($"{n}\t\t{stringTime} ms\t\t{builderTime} ms\t\t\t{bufferTime} ms");
        }
    }

    // Using string (Immutable → O(N^2))
    static long TestString(int n)
    {
        Stopwatch sw = new Stopwatch();
        string result = "";

        sw.Start();
        for (int i = 0; i < n; i++)
        {
            result += "a";
        }
        sw.Stop();

        return sw.ElapsedMilliseconds;
    }

    // Using StringBuilder (Mutable, Fast → O(N))
    static long TestStringBuilder(int n)
    {
        Stopwatch sw = new Stopwatch();
        StringBuilder sb = new StringBuilder();

        sw.Start();
        for (int i = 0; i < n; i++)
        {
            sb.Append("a");
        }
        sw.Stop();

        return sw.ElapsedMilliseconds;
    }

    // Simulating StringBuffer using lock (Thread-safe → O(N))
    static long TestStringBuffer(int n)
    {
        Stopwatch sw = new Stopwatch();
        StringBuilder sb = new StringBuilder();

        sw.Start();
        for (int i = 0; i < n; i++)
        {
            lock (lockObj)
            {
                sb.Append("a");
            }
        }
        sw.Stop();

        return sw.ElapsedMilliseconds;
    }
}
