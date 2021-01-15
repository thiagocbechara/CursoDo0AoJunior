using System;

namespace CursoDo0AoJunior.Modulo3.EstruturaDeDados.Stack
{
    public sealed class StackArray<T>
    {
        public StackArray(int size = 0)
        {
            Items = new T[size * 2];
        }

        private T[] Items { get; set; }
        public int Count { get; private set; }

        public StackArray<T> Push(T item)
        {
            if (Count == Items.Length)
            {
                var newLength = Count == 0 ? 4 : Count * 2;
                var newArray = new T[newLength];
                Items.CopyTo(newArray, 0);
                Items = newArray;
            }
            Items[Count++] = item;
            return this;
        }

        public T Pop()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Empty stack");
            }
            return Items[--Count];
        }

        public T Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Empty stack");
            }
            return Items[Count - 1];
        }
    }
}