using System;

public class Remove_Duplicates_Array
{
    public static int RemoveDuplicates(int[] nums)
    {
        if (nums.Length == 0) return 0; // edge case

        int k = 1; // position for next unique element

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] != nums[i - 1])
            {
                nums[k] = nums[i]; // overwrite at position k
                k++;               // move k to next position
            }
        }

        return k;
    }

    public static void Main(string[] args)
    {
        int[] nums = {1, 1, 2, 2, 3, 4, 4};

        int k = RemoveDuplicates(nums);

        Console.WriteLine("Number of unique elements: " + k);
        Console.Write("Array after removing duplicates: ");

        for (int i = 0; i < k; i++)
        {
            Console.Write(nums[i] + " ");
        }
    }
}
