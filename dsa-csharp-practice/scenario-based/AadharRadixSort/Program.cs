using System;

class Program
{
    static void Main()
    {
        long[] aadharNumbers =
        {
            234567890123,
            123456789012,
            234567890111,
            123456789045,
            234567890123
        };

        Console.WriteLine("Before Sorting:");
        Display(aadharNumbers);

        RadixSort sorter = new RadixSort();
        sorter.Sort(aadharNumbers);

        Console.WriteLine("\nAfter Sorting:");
        Display(aadharNumbers);

        // Binary Search
        long target = 123456789012;
        int index = sorter.BinarySearch(aadharNumbers, target);

        if (index != -1)
            Console.WriteLine("\nAadhar found at index: " + index);
        else
            Console.WriteLine("\nAadhar not found");
    }

    static void Display(long[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.WriteLine(arr[i]);
        }
    }
}
