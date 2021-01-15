using System;

namespace CursoDo0AoJunior.Modulo3.Execucao.Recursao
{
    public class RecursaoTeste
    {
        public static decimal Pow(decimal number, decimal power)
        {
            if (power == 0)
            {
                return 1;
            }
            return number * Pow(number, power - 1);
        }

        public static decimal Fatorial(decimal number)
        {
            if (number == 0)
            {
                return 1;
            }
            return number * Fatorial(number - 1);
        }
    }
}