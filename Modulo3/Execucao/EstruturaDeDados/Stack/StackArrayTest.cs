using System;
using CursoDo0AoJunior.Modulo3.EstruturaDeDados.Stack;

namespace CursoDo0AoJunior.Modulo3.Execucao.EstruturaDeDados.Stack
{
    public static class StackArrayTeste
    {
        public static void ExecutarTeste()
        {
            var stack = new StackArray<int>();
            stack.Push(1)
                .Push(2)
                .Push(3)
                .Push(4)
                .Push(5);
            Console.WriteLine($"Stack count: {stack.Count}");
            var peek = stack.Peek();
            Console.WriteLine($"Stack peek: {peek}");
            Console.WriteLine($"Stack count: {stack.Count}");
            Console.WriteLine("------------------");
            do
            {
                try
                {
                    var pop = stack.Pop();
                    Console.WriteLine($"Pop: {pop}. New count: {stack.Count}");
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                    break;
                }
            } while (true);
            Console.WriteLine("END TEST STACK");
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}