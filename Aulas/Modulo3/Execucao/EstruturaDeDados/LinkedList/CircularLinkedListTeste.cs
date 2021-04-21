using System;
using CursoDo0AoJunior.Modulo3.EstruturaDeDados.LinkedList;

namespace CursoDo0AoJunior.Modulo3.Execucao.EstruturaDeDados.LinkedList
{
    public static class CircularLinkedListTeste
    {
        public static void ExecutarTeste()
        {
            var head = new CircularLinkedList("Valor 1");
            head.Append("Valor 2")
                .Append("Valor 3")
                .Append("Valor 4")
                .Append("Valor 5")
                .Append("Valor 6");

            Console.WriteLine("EXECUTANDO TESTES CIRCULAR LINKED LIST");
            Console.WriteLine($"Comprimento da lista: {head.Length}");
            var nextNode = head;
            do
            {
                Console.WriteLine($"Posição: {nextNode.Position}");
                Console.WriteLine($"Atual: {nextNode.Value}");
                Console.WriteLine($"Head: {nextNode.Head.Value}");
                Console.WriteLine($"Tail: {nextNode.Tail.Value}");
                Console.WriteLine($"Next: {nextNode.NextNode.Value}");
                nextNode = nextNode.NextNode;
                Console.WriteLine("-----------------------------");
            } while (nextNode.Position != nextNode.Head.Position);   
            Console.WriteLine("FIM DO TESTE CIRCULAR LINKED LIST");
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}