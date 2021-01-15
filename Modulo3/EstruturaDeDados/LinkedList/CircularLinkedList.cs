using System;

namespace CursoDo0AoJunior.Modulo3.EstruturaDeDados.LinkedList
{
    public class CircularLinkedList
    {
        public CircularLinkedList(string value)
        {
            Head = Tail = NextNode = this;
            Length = 1;
            Position = 1;
            Value = value;
        }

        public CircularLinkedList Head { get; private set; }
        public CircularLinkedList Tail { get; private set; }
        public CircularLinkedList NextNode { get; private set; }
        public int Length { get; private set; }
        public int Position { get; private set; }
        public string Value { get; set; }

        public CircularLinkedList Append(string value)
        {
            var newNode = new CircularLinkedList(value)
            {
                Head = Head
            };
            Append(newNode);
            return this;
        }

        private void Append(CircularLinkedList node)
        {
            Length++;
            Tail = node;
            if (NextNode == Head)
            {
                node.Length = node.Position = Length;
                node.Tail = node;
                node.NextNode = Head;
                NextNode = node;
                return;
            }
            NextNode.Append(node);
        }

        public CircularLinkedList GetNodeAt(int position)
        {
            if (Position == position)
            {
                return this;
            }
            return NextNode.GetNodeAt(position);
        }
    }
}