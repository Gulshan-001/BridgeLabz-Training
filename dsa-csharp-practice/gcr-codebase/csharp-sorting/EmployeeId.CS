using System;

class EmployeeId
{
    static void Main()
    {
        // Unsorted employee IDs
        int[] empIds = { 104, 101, 109, 102, 106 };

        int n = empIds.Length;

        // Insertion Sort logic
        for (int i = 1; i < n; i++)
        {
            int key = empIds[i];   // current element
            int j = i - 1;

            // move elements greater than key to one position ahead
            while (j >= 0 && empIds[j] > key)
            {
                empIds[j + 1] = empIds[j];
                j--;
            }

            // insert key at correct position
            empIds[j + 1] = key;
        }

        // Display sorted employee IDs
        Console.WriteLine("Employee IDs in ascending order:");
        foreach (int id in empIds)
        {
            Console.Write(id + " ");
        }
    }
}
