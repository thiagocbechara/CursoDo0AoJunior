using System;
using CursoDo0AoJunior.Modulo3.Execucao.EstruturaDeDados.LinkedList;
using CursoDo0AoJunior.Modulo3.Execucao.EstruturaDeDados.Queue;
using CursoDo0AoJunior.Modulo3.Execucao.EstruturaDeDados.Stack;

namespace CursoDo0AoJunior
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ExecutarTestesLinkedList();
        }

        private static void ExecutarTestesLinkedList()
        {
            SinglyLinkedListTeste.ExecutarTeste();
            DoublyLinkedListTeste.ExecutarTeste();
            CircularLinkedListTeste.ExecutarTeste();

            StackArrayTeste.ExecutarTeste();

            QueueArrayTeste.ExecutarTeste();
        }
    }
}