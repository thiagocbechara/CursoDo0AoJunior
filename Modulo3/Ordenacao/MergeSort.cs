using System;
using System.Linq;

namespace CursoDo0AoJunior.Modulo3.Ordenacao
{
    public class MergeSort: BaseSortAlgorithms
    {
        public static int[] Sort(int[] array)
       {
           if (array.Length <= 1)
           {
               return array;
           }
           var midPoint = array.Length / 2;
           var left = array.Take(midPoint).ToArray();
           var right = array.Skip(midPoint).ToArray();
           Sort(left);
           Sort(right);
           return Merge(left, right, array);
       }
       private static int[] Merge(int[] leftMost, int[] rightMost, int[] array)
       {
           var index = 0;
          
           while (leftMost.Length > 0 && rightMost.Length > 0)
           {
               if (leftMost[0] < rightMost[0])
               {
                   array[index++] = leftMost.First();
                   leftMost = leftMost.Skip(1).ToArray();
               }
               else
               {
                   array[index++] = rightMost.First();

                   rightMost = rightMost.Skip(1).ToArray();
               }
           }

           while (leftMost.Length > 0)
           {
               array[index++] = leftMost.First();
               leftMost = leftMost.Skip(1).ToArray();
           }

           while (rightMost.Length > 0)
           {
               array[index++] = rightMost.First();
               rightMost = rightMost.Skip(1).ToArray();
           }

           return array;
       }
    }
}