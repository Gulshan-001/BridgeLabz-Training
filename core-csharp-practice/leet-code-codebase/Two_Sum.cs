using System;

public class Two_Sum
{
    public int[] TwoSum(int[] nums, int target)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] + nums[j] == target)
                {
                    return new int[] { i, j };
                }
            }
        }
        return new int[] { -1, -1 };
    }

    public static void Main(string[] args)
    {
        Two_Sum ts = new Two_Sum();
        int[] nums = { 2, 7, 11, 15 };
        int target = 9;
        int[] result = ts.TwoSum(nums, target);
        Console.WriteLine($"Indices: [{result[0]}, {result[1]}]");
    }
}
