using System;
using CursoDo0AoJunior.Modulo3.EstruturaDeDados.Queue;

namespace CursoDo0AoJunior.Modulo3.Execucao.EstruturaDeDados.Queue
{
    public static class QueueArrayTeste
    {
        public static void ExecutarTeste()
        { 
            var queue = new QueueArray<int>();
            queue.Enqueue(1)
                .Enqueue(2)
                .Enqueue(3)
                .Enqueue(4)
                .Enqueue(5);
            Console.WriteLine($"Queue count: {queue.Count}");
            var peek = queue.Peek();
            Console.WriteLine($"Queue peek: {peek}");
            Console.WriteLine($"Queue count: {queue.Count}");
            Console.WriteLine("------------------");
            do
            {
                try
                {
                    var dequeue = queue.Dequeue();
                    Console.WriteLine($"Dequeue: {dequeue}. New count: {queue.Count}");
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                    break;
                }
            } while (true);
            Console.WriteLine("END TEST QUEUE");
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}