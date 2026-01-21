public class MergeSort
{
    public static void Sort(RankUtility.Student[] students, int count)
    {
        if (count <= 1)
            return;

        MergeSortInternal(students, 0, count - 1);
    }

    private static void MergeSortInternal(RankUtility.Student[] students, int left, int right)
    {
        if (left >= right)
            return;

        int mid = (left + right) / 2;

        MergeSortInternal(students, left, mid);
        MergeSortInternal(students, mid + 1, right);

        Merge(students, left, mid, right);
    }

    private static void Merge(RankUtility.Student[] students, int left, int mid, int right)
    {
        int size = right - left + 1;
        RankUtility.Student[] temp = new RankUtility.Student[size];

        int i = left, j = mid + 1, k = 0;

        // Pick higher marks first, keep left student if marks are equal
        while (i <= mid && j <= right)
        {
            if (students[i].Marks >= students[j].Marks)
                temp[k++] = students[i++];
            else
                temp[k++] = students[j++];
        }

        while (i <= mid)
            temp[k++] = students[i++];

        while (j <= right)
            temp[k++] = students[j++];

        for (int t = 0; t < size; t++)
            students[left + t] = temp[t];
    }
}
