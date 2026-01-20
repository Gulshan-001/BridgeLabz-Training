using System;

class RadixSort
{
    // PUBLIC method to sort
    public void Sort(long[] arr)
    {
        long max = GetMax(arr);

        for (long exp = 1; max / exp > 0; exp *= 10)
        {
            CountingSort(arr, exp);
        }
    }

    // ---------- COUNTING SORT (STABLE) ----------
    private void CountingSort(long[] arr, long exp)
    {
        int n = arr.Length;
        long[] output = new long[n];
        int[] count = new int[10];

        // count digits
        for (int i = 0; i < n; i++)
        {
            int digit = (int)((arr[i] / exp) % 10);
            count[digit]++;
        }

        // cumulative count
        for (int i = 1; i < 10; i++)
        {
            count[i] += count[i - 1];
        }

        // build output (RIGHT TO LEFT → stability)
        for (int i = n - 1; i >= 0; i--)
        {
            int digit = (int)((arr[i] / exp) % 10);
            output[count[digit] - 1] = arr[i];
            count[digit]--;
        }

        // copy back
        for (int i = 0; i < n; i++)
        {
            arr[i] = output[i];
        }
    }

    // ---------- GET MAX ----------
    private long GetMax(long[] arr)
    {
        long max = arr[0];
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] > max)
                max = arr[i];
        }
        return max;
    }

    // ---------- BINARY SEARCH ----------
    public int BinarySearch(long[] arr, long target)
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
