using System;

class ProductPrices
{
    static void Main()
    {
        // Product prices array
        int[] prices = { 1200, 450, 999, 300, 1500, 700 };

        // Call quick sort
        QuickSort(prices, 0, prices.Length - 1);

        // Display sorted prices
        Console.WriteLine("Product prices in ascending order:");
        foreach (int price in prices)
        {
            Console.Write(price + " ");
        }
    }

    // Quick Sort method
    static void QuickSort(int[] arr, int low, int high)
    {
        if (low < high)
        {
            // Get partition index
            int pi = Partition(arr, low, high);

            // Sort left side
            QuickSort(arr, low, pi - 1);

            // Sort right side
            QuickSort(arr, pi + 1, high);
        }
    }

    // Partition logic
    static int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[high]; // choosing last element as pivot
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            // if current element is smaller than pivot
            if (arr[j] < pivot)
            {
                i++;

                // swap arr[i] and arr[j]
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }

        // place pivot in correct position
        int temp2 = arr[i + 1];
        arr[i + 1] = arr[high];
        arr[high] = temp2;

        return i + 1; // partition index
    }
}
