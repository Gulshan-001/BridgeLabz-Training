public class MergeSort
{
    // Used by districts
    public static void Sort(RankUtility.Student[] arr, int count)
    {
        if (count <= 1) return;
        MergeSortInternal(arr, 0, count - 1);
    }

    private static void MergeSortInternal(RankUtility.Student[] arr, int left, int right)
    {
        if (left >= right) return;

        int mid = (left + right) / 2;

        MergeSortInternal(arr, left, mid);
        MergeSortInternal(arr, mid + 1, right);

        Merge(arr, left, mid, right);
    }

    private static void Merge(RankUtility.Student[] arr, int left, int mid, int right)
    {
        int size = right - left + 1;
        RankUtility.Student[] temp = new RankUtility.Student[size];

        int i = left, j = mid + 1, k = 0;

        // Stable merge
        while (i <= mid && j <= right)
        {
            if (arr[i].Marks >= arr[j].Marks)
                temp[k++] = arr[i++];
            else
                temp[k++] = arr[j++];
        }

        while (i <= mid) temp[k++] = arr[i++];
        while (j <= right) temp[k++] = arr[j++];

        for (int t = 0; t < size; t++)
            arr[left + t] = temp[t];
    }

    // STATE LEVEL MERGE (MERGING DISTRICTS)
    public static RankUtility.Student[] MergeDistricts(
        RankUtility.Student[] d1, int c1,
        RankUtility.Student[] d2, int c2)
    {
        RankUtility.Student[] state = new RankUtility.Student[c1 + c2];

        int i = 0, j = 0, k = 0;

        // Merge two sorted district lists
        while (i < c1 && j < c2)
        {
            // Stable: district 1 stays first if marks equal
            if (d1[i].Marks >= d2[j].Marks)
                state[k++] = d1[i++];
            else
                state[k++] = d2[j++];
        }

        while (i < c1) state[k++] = d1[i++];
        while (j < c2) state[k++] = d2[j++];

        return state;
    }
}
