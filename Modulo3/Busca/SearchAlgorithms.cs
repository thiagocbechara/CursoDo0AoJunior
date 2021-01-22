using System;

namespace CursoDo0AoJunior.Modulo3.Busca
{
    public static class SearchAlgorithms
    {
        public static int LinearSearch(int[] array, int key)
        {
            for (var i = 0; i < array.Length; i++)
            {
                if (key == array[i]) return array[i];
            }
            return int.MaxValue;
        }

        public static int BinarySearch(int[] array, int key)
        {
            if (array.Length == 0)
            {
                return int.MinValue;
            }
            var middleIndex = array.Length / 2;
            var middleValue = array[middleIndex];
            if (key == middleValue) return middleValue;
            if (key > middleValue)
            {
                var splitedArray = new int[middleIndex];
                Array.Copy(array, middleIndex, splitedArray, 0, middleIndex);
                return BinarySearch(splitedArray, key);
            }
            if (key < middleValue)
            {
                var splitedArray = new int[middleIndex];
                Array.Copy(array, 0, splitedArray, 0, middleIndex);
                return BinarySearch(splitedArray, key);
            }
            return int.MaxValue;
        }
    }
}