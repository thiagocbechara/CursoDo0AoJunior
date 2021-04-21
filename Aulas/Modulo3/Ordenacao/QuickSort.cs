using System;

namespace CursoDo0AoJunior.Modulo3.Ordenacao
{
    public class QuickSort : BaseSortAlgorithms
    {
        public static int[] Sort(int[] array)
        {
            var sortedArray = new int[array.Length];
            array.CopyTo(sortedArray, 0);
            Sort(sortedArray, 0, sortedArray.Length - 1);
            return sortedArray;
        }

        private static void Sort(int[] array, int begin, int end)
        {
            if (begin < end)
            {
                var p = array[begin];
                var i = begin + 1;
                var f = end;

                while (i <= f)
                {
                    if (array[i] <= p)
                    {
                        i++;
                    }
                    else if (p < array[f])
                    {
                        f--;
                    }
                    else
                    {
                        var swap = array[i];
                        array[i] = array[f];
                        array[f] = swap;
                        i++;
                        f--;
                    }
                }

                array[begin] = array[f];
                array[f] = p;

                Sort(array, begin, f - 1);
                Sort(array, f + 1, end);
            }
        }
    }
}