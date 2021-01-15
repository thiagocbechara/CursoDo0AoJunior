using System;
using CursoDo0AoJunior.Modulo3.EstruturaDeDados.LinkedList;

namespace CursoDo0AoJunior.Modulo3.Execucao.EstruturaDeDados.LinkedList
{
    public static class SinglyLinkedListTeste
    {
        public static void ExecutarTeste()
        {
            var head = new SinglyLinkedList("Valor 1");
            head.Append("Valor 2")
                .Append("Valor 3")
                .Append("Valor 4")
                .Append("Valor 5")
                .Append("Valor 6");

            Console.WriteLine("EXECUTANDO TESTES SINGLY LINKED LIST");
            Console.WriteLine($"Comprimento da lista: {head.Length}");
            var nextNode = head;
            for (var i = 1; i <= head.Length; i++)
            {
                // Console.WriteLine(singly.GetNodeAt(i).Value);
                Console.WriteLine($"Atual: {nextNode.Value}");
                Console.WriteLine($"Head: {nextNode.Head.Value}");
                Console.WriteLine($"Tail: {nextNode.Tail.Value}");
                nextNode = nextNode.NextNode;
                Console.WriteLine("-----------------------------");
            }
            Console.WriteLine("FIM DO TESTE SINGLY LINKED LIST");
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}