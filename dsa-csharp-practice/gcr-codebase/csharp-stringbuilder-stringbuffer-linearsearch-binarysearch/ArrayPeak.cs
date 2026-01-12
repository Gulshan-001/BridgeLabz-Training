using System;

class ArrayPeak
{
    static void Main()
    {
        int[] arr = { 1, 3, 20, 4, 1, 0 };

        int peakIndex = FindPeakElement(arr);

        Console.WriteLine("Peak element index: " + peakIndex);
        Console.WriteLine("Peak element value: " + arr[peakIndex]);
    }

    static int FindPeakElement(int[] arr)
    {
        int left = 0;
        int right = arr.Length - 1;

        while (left < right)
        {
            int mid = left + (right - left) / 2;

            // Compare mid with its right neighbor
            if (arr[mid] < arr[mid + 1])
            {
                // Peak lies on the right side
                left = mid + 1;
            }
            else
            {
                // Peak lies on the left side or at mid
                right = mid;
            }
        }

        return left; // Index of a peak element
    }
}
