using System;

namespace CursoDo0AoJunior.Modulo3.EstruturaDeDados.LinkedList
{
    public class SinglyLinkedList
    {
        public SinglyLinkedList(string value)
        {
            Head = Tail = this;
            Length = 1;
            Position = 1;
            Value = value;
        }

        public SinglyLinkedList Head { get; private set; }
        public SinglyLinkedList Tail { get; private set; }
        public SinglyLinkedList NextNode { get; private set; }
        public int Length { get; private set; }
        public int Position { get; private set; }
        public string Value { get; set; }

        public SinglyLinkedList Append(string value)
        {
            var newNode = new SinglyLinkedList(value)
            {
                Head = Head
            };
            Append(newNode);
            return this;
        }

        private void Append(SinglyLinkedList node)
        {
            Length++;
            Tail = node;
            if (NextNode == null)
            {
                node.Length = node.Position = Length;
                node.Tail = node;
                NextNode = node;
                return;
            }
            NextNode.Append(node);
        }

        public SinglyLinkedList GetNodeAt(int position)
        {
            if (Position == position)
            {
                return this;
            }
            return NextNode.GetNodeAt(position);
        }
    }
}
