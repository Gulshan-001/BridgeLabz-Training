using System;
using System.Collections.Generic;

class LongestConsecutiveSequence
{
    static int FindLongestConsecutive(int[] arr)
    {
        HashSet<int> set = new HashSet<int>();
        int longest = 0;

        // Step 1: Add all elements to set
        foreach (int num in arr)
            set.Add(num);

        // Step 2: Find longest sequence
        foreach (int num in set)
        {
            // Start only if num is the beginning
            if (!set.Contains(num - 1))
            {
                int currentNum = num;
                int count = 1;

                while (set.Contains(currentNum + 1))
                {
                    currentNum++;
                    count++;
                }

                longest = Math.Max(longest, count);
            }
        }

        return longest;
    }

    static void Main()
    {
        int[] arr = { 100, 4, 200, 1, 3, 2 };
        Console.WriteLine("Longest Consecutive Length: " +
                          FindLongestConsecutive(arr));
    }
}
