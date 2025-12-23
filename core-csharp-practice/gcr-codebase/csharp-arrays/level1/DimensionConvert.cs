using System;

class DimensionConvert
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter number of rows:");
        int rows = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter number of columns:");
        int columns = Convert.ToInt32(Console.ReadLine());

        // Creating the 2D array (matrix)
        int[,] matrix = new int[rows, columns];

        Console.WriteLine("Enter the elements of the matrix:");

        // Taking input for the 2D array
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Console.Write("Element [" + i + "," + j + "]: ");
                matrix[i, j] = Convert.ToInt32(Console.ReadLine());
            }
        }

        // Creating 1D array to store all elements
        int[] array = new int[rows * columns];
        int index = 0;

        // Copying elements from 2D array to 1D array
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                array[index] = matrix[i, j];
                index++;
            }
        }

        Console.WriteLine();
        Console.WriteLine("Elements in the 1D array:");

        // Displaying the 1D array
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }
    }
}
