using System;

namespace CursoDo0AoJunior.Modulo3.Ordenacao
{
    public class InsertionSort : BaseSortAlgorithms
    {
        public static int[] Sort(int[] array)
        {
            var sortedArray = new int[array.Length];
            array.CopyTo(sortedArray, 0);
            for (var i = 1; i < sortedArray.Length; i++)
            {
                var element = sortedArray[i];
                var j = i;
                while (j > 0 && sortedArray[j - 1] > element)
                {
                    sortedArray[j] = sortedArray[j - 1];
                    j--;
                }
                sortedArray[j] = element;
            }
            return sortedArray;
        }
    }
}