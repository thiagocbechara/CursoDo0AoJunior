using System;

namespace CursoDo0AoJunior.Modulo3.EstruturaDeDados.Queue
{
    public sealed class QueueArray<T>
    {
        public QueueArray(int size = 0)
        {
            Items = new T[size * 2];
        }
        private T[] Items { get; set; }
        private int Front { get; set; }
        public int Count { get; private set; }

        public T Dequeue()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Empty queue");
            }
            Count--;
            return Items[Front++];
        }

        public QueueArray<T> Enqueue(T item)
        {
            if (Count == Items.Length)
            {
                var newLength = Count == 0 ? 4 : Count * 2;
                var newArray = new T[newLength];
                Items.CopyTo(newArray, Front);
                Items = newArray;
            }
            Items[Count++] = item;
            return this;
        }

        public T Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Empty queue");
            }
            return Items[Front];
        }
    }
}