using System;

class BinaryPlusLinear
{
    static void Main()
    {
        int[] arr = { 3, 4, -1, 1 };
        int target = 4;

        int missingPositive = FindFirstMissingPositive(arr);
        Console.WriteLine("First missing positive integer: " + missingPositive);

        Array.Sort(arr); // Required before Binary Search

        int targetIndex = BinarySearch(arr, target);
        Console.WriteLine("Index of target element: " + targetIndex);
    }

    // 🔹 Linear Search to find first missing positive integer
    static int FindFirstMissingPositive(int[] arr)
    {
        int n = arr.Length;
        bool[] visited = new bool[n + 1];

        // Mark positive numbers
        for (int i = 0; i < n; i++)
        {
            if (arr[i] > 0 && arr[i] <= n)
            {
                visited[arr[i]] = true;
            }
        }

        // Find first missing positive
        for (int i = 1; i <= n; i++)
        {
            if (!visited[i])
                return i;
        }

        return n + 1;
    }

    // 🔹 Binary Search to find target index
    static int BinarySearch(int[] arr, int target)
    {
        int left = 0, right = arr.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

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
