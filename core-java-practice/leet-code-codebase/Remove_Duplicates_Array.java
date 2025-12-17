
class Remove_Duplicates_Array {

    public static int removeDuplicates(int[] nums) {
        if (nums.length == 0) return 0; // edge case

        int k = 1; // position for next unique element

        for (int i = 1; i < nums.length; i++) {
            if (nums[i] != nums[i - 1]) {
                nums[k] = nums[i]; // overwrite at position k
                k++;               // move k to next position
            }
        }

        return k;
    }

    public static void main(String[] args) {
        int[] nums = {1, 1, 2, 2, 3, 4, 4};

        int k = removeDuplicates(nums);

        System.out.println("Number of unique elements: " + k);
        System.out.print("Array after removing duplicates: ");

        for (int i = 0; i < k; i++) {
            System.out.print(nums[i] + " ");
        }
    }
}
