using System;
using System.Diagnostics;

class SearchComparison
{
    static void Main()
    {
        int[] sizes = { 1000, 10000, 1000000 };

        foreach (int size in sizes)
        {
            Console.WriteLine("\nDataset Size: " + size);

            int[] data = new int[size];

            // Fill array
            for (int i = 0; i < size; i++)
            {
                data[i] = i;
            }

            int target = size - 1;

            // -------- Linear Search --------
            Stopwatch sw = Stopwatch.StartNew();
            LinearSearch(data, target);
            sw.Stop();
            Console.WriteLine("Linear Search Time: " + sw.ElapsedMilliseconds + " ms");

            // -------- Binary Search --------
            sw.Restart();
            BinarySearch(data, target);
            sw.Stop();
            Console.WriteLine("Binary Search Time: " + sw.ElapsedMilliseconds + " ms");
        }
    }

    static int LinearSearch(int[] arr, int target)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == target)
                return i;
        }
        return -1;
    }

    static int BinarySearch(int[] arr, int target)
    {
        int left = 0;
        int right = arr.Length - 1;

        while (left <= right)
        {
            int mid = (left + right) / 2;

            if (arr[mid] == target)
                return mid;
            else if (arr[mid] < target)
                left = mid + 1;
            else
                right = mid - 1;
        }
        return -1;
    }
}
