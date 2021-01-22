using System;

namespace CursoDo0AoJunior.Modulo3.Ordenacao
{
    public class SelectionSort : BaseSortAlgorithms
    {
        public static int[] Sort(int[] array)
        {
            var sortedArray = new int[array.Length];
            array.CopyTo(sortedArray, 0);
            for (var i = 0; i < sortedArray.Length - 1; i++)
            {
                var min = i;
                for (var j = i + 1; j < sortedArray.Length; j++)
                    if (sortedArray[j] < sortedArray[min]) min = j;

                if (min != i)
                {
                    Swap(sortedArray, min, i);
                }
            }
            return sortedArray;
        }

    }
}