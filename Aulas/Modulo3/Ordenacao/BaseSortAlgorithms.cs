using System;

namespace CursoDo0AoJunior.Modulo3.Ordenacao
{
    public class BaseSortAlgorithms
    {
        protected static void Swap(int[] v, int j, int newJ)
        {
            var aux = v[j];
            v[j] = v[newJ];
            v[newJ] = aux;
        }
    }
}