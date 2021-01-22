using System;

namespace CursoDo0AoJunior.Modulo3.Ordenacao
{
    public class HeapSort : BaseSortAlgorithms
    {
        public static int[] Sort(int[] array)
        {
            var sortedArray = new int[array.Length];
            array.CopyTo(sortedArray, 0);
            BuildMaxHeap(sortedArray);
            var n = sortedArray.Length;

            for (int i = sortedArray.Length - 1; i > 0; i--)
            {
                Swap(sortedArray, i, 0);
                MaxHeapify(sortedArray, 0, --n);
            }
            return sortedArray;
        }

        private static void BuildMaxHeap(int[] v)
        {
            for (int i = v.Length / 2 - 1; i >= 0; i--)
            {
                MaxHeapify(v, i, v.Length);
            }
        }

        private static void MaxHeapify(int[] v, int pos, int n)
        {
            int max = 2 * pos + 1, right = max + 1;
            if (max < n)
            {
                if (right < n && v[max] < v[right])
                {
                    max = right;
                }
                if (v[max] > v[pos])
                {
                    Swap(v, max, pos);
                    MaxHeapify(v, max, n);
                }
            }
        }
    }
}