using System;
using System.Collections.Generic;

class SlidingWindowMax
{
    static void MaxSlidingWindow(int[] nums, int k)
    {
        LinkedList<int> deque = new LinkedList<int>(); // stores indices
        List<int> result = new List<int>();

        for (int i = 0; i < nums.Length; i++)
        {
            // Remove indices out of current window
            if (deque.Count > 0 && deque.First.Value == i - k)
            {
                deque.RemoveFirst();
            }

            // Remove smaller elements from the back
            while (deque.Count > 0 && nums[deque.Last.Value] <= nums[i])
            {
                deque.RemoveLast();
            }

            // Add current index
            deque.AddLast(i);

            // Add max for current window
            if (i >= k - 1)
            {
                result.Add(nums[deque.First.Value]);
            }
        }

        Console.WriteLine("Sliding Window Maximum:");
        foreach (int val in result)
            Console.Write(val + " ");
    }

    static void Main()
    {
        int[] nums = { 1, 3, -1, -3, 5, 3, 6, 7 };
        int k = 3;

        MaxSlidingWindow(nums, k);
    }
}
