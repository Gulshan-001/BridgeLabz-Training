using System;

class JobSalaries
{
    static void Main()
    {
        int[] salaries = { 60000, 45000, 80000, 50000, 70000 };

        int n = salaries.Length;

        // Step 1: Build Max Heap
        for (int i = n / 2 - 1; i >= 0; i--)
            Heapify(salaries, n, i);

        // Step 2: Extract elements from heap
        for (int i = n - 1; i > 0; i--)
        {
            // Swap root with last element
            int temp = salaries[0];
            salaries[0] = salaries[i];
            salaries[i] = temp;

            // Heapify reduced heap
            Heapify(salaries, i, 0);
        }

        // Display sorted salaries
        Console.WriteLine("Salaries in ascending order:");
        foreach (int salary in salaries)
            Console.Write(salary + " ");
    }

    // Heapify method
    static void Heapify(int[] arr, int n, int i)
    {
        int largest = i;
        int left = 2 * i + 1;
        int right = 2 * i + 2;

        if (left < n && arr[left] > arr[largest])
            largest = left;

        if (right < n && arr[right] > arr[largest])
            largest = right;

        if (largest != i)
        {
            int swap = arr[i];
            arr[i] = arr[largest];
            arr[largest] = swap;

            Heapify(arr, n, largest);
        }
    }
}
