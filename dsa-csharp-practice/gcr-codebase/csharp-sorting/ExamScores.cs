using System;

class ExamScores
{
    static void Main()
    {
        // Exam scores array
        int[] scores = { 78, 45, 90, 62, 88, 50 };

        // Selection Sort
        for (int i = 0; i < scores.Length - 1; i++)
        {
            int minIndex = i;

            // Find minimum element in unsorted part
            for (int j = i + 1; j < scores.Length; j++)
            {
                if (scores[j] < scores[minIndex])
                {
                    minIndex = j;
                }
            }

            // Swap minimum with first unsorted element
            int temp = scores[minIndex];
            scores[minIndex] = scores[i];
            scores[i] = temp;
        }

        // Display sorted scores
        Console.WriteLine("Exam scores in ascending order:");
        foreach (int score in scores)
        {
            Console.Write(score + " ");
        }
    }
}
