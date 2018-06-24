using System;

namespace InversionCount
{
    public class InversionCounter<T> where T : IComparable
    {

        private static T[] aux;

        public static int CountInversions(int[] arr)
        {
            int[] temp = new int[arr.Length];
            return MergeSort(arr, temp, 0, arr.Length - 1);
        }

        private static int MergeSort(int[] arr, int[] temp, int left, int right)
        {
            int mid, inversions = 0;
            if (right > left)
            {
                mid = (right + left) / 2;
                inversions = MergeSort(arr, temp, left, mid);
                inversions += MergeSort(arr, temp, mid + 1, right);

                inversions += Merge(arr, temp, left, mid + 1, right);
            }
            return inversions;
        }

        private static int Merge(int[] arr, int[] temp, int left, int mid, int right)
        {
            int i, j, k;
            int inversions = 0;

            i = left;
            j = mid;
            k = left;
            while ((i <= mid - 1) && (j <= right))
            {
                if (arr[i] <= arr[j])
                {
                    temp[k++] = arr[i++];
                }
                else
                {
                    temp[k++] = arr[j++];
                    inversions = inversions + (mid - i);
                }
            }

            while (i <= mid - 1)
            {
                temp[k++] = arr[i++];
            }
            while (j <= right)
            {
                temp[k++] = arr[j++];
            }
            for (i = left; i <= right; i++)
            {
                arr[i] = temp[i];
            }
            return inversions;
        }
        private static bool IsLess(T i, T j)
        {
            return i.CompareTo(j) < 0;
        }
    }
}
