using System;

namespace CursoDo0AoJunior.Modulo3.Ordenacao
{
    public class BubbleSort : BaseSortAlgorithms
    {
        public static int[] Sort(int[] array)
        {
            var sortedArray = new int[array.Length];
            array.CopyTo(sortedArray, 0);
            for (var i = sortedArray.Length - 1; i >= 1; i--)
            {
                for (var j = 0; j < i; j++)
                {
                    if (sortedArray[j] > sortedArray[j + 1])
                    {
                        Swap(sortedArray, j, j + 1);
                    }
                }
            }
            return sortedArray;
        }
    }
}