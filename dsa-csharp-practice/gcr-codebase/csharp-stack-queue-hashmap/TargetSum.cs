using System;
using System.Collections.Generic;

class TargetSum
{
    static bool HasPair(int[] arr, int target)
    {
        HashSet<int> set = new HashSet<int>();

        foreach (int num in arr)
        {
            int required = target - num;

            if (set.Contains(required))
                return true;

            set.Add(num);
        }

        return false;
    }

    static void Main()
    {
        int[] arr = { 8, 4, 1, 6, 2 };
        int target = 10;

        if (HasPair(arr, target))
            Console.WriteLine("Pair exists");
        else
            Console.WriteLine("No such pair");
    }
}
