using System;
using CursoDo0AoJunior.Modulo3.Busca;
using CursoDo0AoJunior.Modulo3.Execucao.EstruturaDeDados.LinkedList;
using CursoDo0AoJunior.Modulo3.Execucao.EstruturaDeDados.Queue;
using CursoDo0AoJunior.Modulo3.Execucao.EstruturaDeDados.Stack;
using CursoDo0AoJunior.Modulo3.Ordenacao;

namespace CursoDo0AoJunior
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ExecutarTestesLinkedList();
            ExercutarTestesOrdenacao();
        }

        private static void ExecutarTestesLinkedList()
        {
            SinglyLinkedListTeste.ExecutarTeste();
            DoublyLinkedListTeste.ExecutarTeste();
            CircularLinkedListTeste.ExecutarTeste();

            StackArrayTeste.ExecutarTeste();

            QueueArrayTeste.ExecutarTeste();
        }

        private static void ExercutarTestesOrdenacao()
        {
            var array = new int[] { 1, 99, 5, 6, 52, 51, 8 };
            Console.WriteLine($"Original array: {string.Join(',', array)}");

            var sortedArray = BubbleSort.Sort(array);
            Console.WriteLine($"BubbleSort: {string.Join(',', sortedArray)}");

            sortedArray = InsertionSort.Sort(array);
            Console.WriteLine($"InsertionSort: {string.Join(',', sortedArray)}");

            sortedArray = SelectionSort.Sort(array);
            Console.WriteLine($"SelectionSort: {string.Join(',', sortedArray)}");

            sortedArray = ShellSort.Sort(array);
            Console.WriteLine($"ShellSort: {string.Join(',', sortedArray)}");

            sortedArray = MergeSort.Sort(array);
            Console.WriteLine($"MergeSort: {string.Join(',', sortedArray)}");

            sortedArray = QuickSort.Sort(array);
            Console.WriteLine($"QuickSort: {string.Join(',', sortedArray)}");
        }
    }
}