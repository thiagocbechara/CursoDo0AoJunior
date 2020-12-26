using System;
using CursoDo0AoJunior.Execucao.EstruturaDeDados.LinkedList;

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
        }
    }
}