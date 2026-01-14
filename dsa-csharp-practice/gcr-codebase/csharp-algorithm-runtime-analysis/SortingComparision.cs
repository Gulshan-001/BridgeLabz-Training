using System;
using System.Diagnostics;

class SortingComparison
{
    static void Main()
    {
        int[] sizes = { 1000, 10000 };

        foreach (int size in sizes)
        {
            Console.WriteLine("\nDataset Size: " + size);

            int[] data1 = GenerateArray(size);
            int[] data2 = (int[])data1.Clone();
            int[] data3 = (int[])data1.Clone();

            Stopwatch sw = new Stopwatch();

            // Bubble Sort
            sw.Start();
            BubbleSort(data1);
            sw.Stop();
            Console.WriteLine("Bubble Sort Time: " + sw.ElapsedMilliseconds + " ms");

            // Merge Sort
            sw.Restart();
            MergeSort(data2, 0, data2.Length - 1);
            sw.Stop();
            Console.WriteLine("Merge Sort Time: " + sw.ElapsedMilliseconds + " ms");

            // Quick Sort
            sw.Restart();
            QuickSort(data3, 0, data3.Length - 1);
            sw.Stop();
            Console.WriteLine("Quick Sort Time: " + sw.ElapsedMilliseconds + " ms");
        }
    }

    static int[] GenerateArray(int size)
    {
        int[] arr = new int[size];
        Random rand = new Random();

        for (int i = 0; i < size; i++)
        {
            arr[i] = rand.Next(1, size);
        }
        return arr;
    }

    // -------- Bubble Sort --------
    static void BubbleSort(int[] arr)
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            for (int j = 0; j < arr.Length - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }

    // -------- Merge Sort --------
    static void MergeSort(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int mid = (left + right) / 2;

            MergeSort(arr, left, mid);
            MergeSort(arr, mid + 1, right);
            Merge(arr, left, mid, right);
        }
    }

    static void Merge(int[] arr, int left, int mid, int right)
    {
        int n1 = mid - left + 1;
        int n2 = right - mid;

        int[] L = new int[n1];
        int[] R = new int[n2];

        for (int i = 0; i < n1; i++)
            L[i] = arr[left + i];

        for (int j = 0; j < n2; j++)
            R[j] = arr[mid + 1 + j];

        int x = 0, y = 0, k = left;

        while (x < n1 && y < n2)
        {
            if (L[x] <= R[y])
                arr[k++] = L[x++];
            else
                arr[k++] = R[y++];
        }

        while (x < n1)
            arr[k++] = L[x++];

        while (y < n2)
            arr[k++] = R[y++];
    }

    // -------- Quick Sort --------
    static void QuickSort(int[] arr, int low, int high)
    {
        if (low < high)
        {
            int pivotIndex = Partition(arr, low, high);

            QuickSort(arr, low, pivotIndex - 1);
            QuickSort(arr, pivotIndex + 1, high);
        }
    }

    static int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[high];
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (arr[j] < pivot)
            {
                i++;
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }

        int t = arr[i + 1];
        arr[i + 1] = arr[high];
        arr[high] = t;

        return i + 1;
    }
}
