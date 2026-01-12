using System;

class TwoDimensionalMatrixSearch
{
    static void Main()
    {
        int[,] matrix =
        {
            { 1, 3, 5, 7 },
            { 10, 11, 16, 20 },
            { 23, 30, 34, 60 }
        };

        int target = 16;

        bool found = SearchMatrix(matrix, target);

        Console.WriteLine(found
            ? "Target found in matrix."
            : "Target not found in matrix.");
    }

    static bool SearchMatrix(int[,] matrix, int target)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        int left = 0;
        int right = rows * cols - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            // Convert 1D index to 2D indices
            int r = mid / cols;
            int c = mid % cols;

            if (matrix[r, c] == target)
                return true;
            else if (matrix[r, c] < target)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return false;
    }
}
