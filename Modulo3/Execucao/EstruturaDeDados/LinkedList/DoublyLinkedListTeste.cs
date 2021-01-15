using System;
using CursoDo0AoJunior.Modulo3.EstruturaDeDados.LinkedList;

namespace CursoDo0AoJunior.Modulo3.Execucao.EstruturaDeDados.LinkedList
{
    public static class DoublyLinkedListTeste
    {
        public static void ExecutarTeste()
        {
            var head = new DoublyLinkedList("Valor 1");
            head.Append("Valor 2")
                .Append("Valor 3")
                .Append("Valor 4")
                .Append("Valor 5")
                .Append("Valor 6");

            Console.WriteLine("EXECUTANDO TESTES DOUBLY LINKED LIST");
            Console.WriteLine($"Comprimento da lista: {head.Length}");
            var nextNode = head;
            do
            {
                Console.WriteLine($"Atual: {nextNode.Value}");
                Console.WriteLine($"Head: {nextNode.Head.Value}");
                Console.WriteLine($"Tail: {nextNode.Tail.Value}");
                Console.WriteLine($"Next: {nextNode.NextNode?.Value}");
                Console.WriteLine($"Previous: {nextNode.PreviousNode?.Value}");
                nextNode = nextNode.NextNode;
                Console.WriteLine("-----------------------------");
            } while (nextNode != null);
            Console.WriteLine("FIM DO TESTE DOUBLY LINKED LIST");
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}