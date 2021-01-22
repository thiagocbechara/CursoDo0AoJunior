using System;

namespace CursoDo0AoJunior.Modulo3.Ordenacao
{
    public class ShellSort : BaseSortAlgorithms
    {
        public static int[] Sort(int[] array)
        {
            var sortedArray = new int[array.Length];
            array.CopyTo(sortedArray, 0);
            var h = 1;
            var n = sortedArray.Length;

            while (h < n)
            {
                h = h * 3 + 1;
            }

            h /= 3;
            int c, j;
            while (h > 0)
            {
                for (var i = h; i < n; i++)
                {
                    c = sortedArray[i];
                    j = i;
                    while (j >= h && sortedArray[j - h] > c)
                    {
                        sortedArray[j] = sortedArray[j - h];
                        j = j - h;
                    }
                    sortedArray[j] = c;
                }
                h /= 2;
            }
            return sortedArray;
        }
    }
}