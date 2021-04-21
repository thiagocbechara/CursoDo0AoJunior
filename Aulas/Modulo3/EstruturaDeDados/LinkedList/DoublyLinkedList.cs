using System;

namespace CursoDo0AoJunior.Modulo3.EstruturaDeDados.LinkedList
{
    public class DoublyLinkedList
    {
        public DoublyLinkedList(string value)
        {
            Head = Tail = this;
            Length = 1;
            Position = 1;
            Value = value;
        }

        public DoublyLinkedList Head { get; private set; }
        public DoublyLinkedList Tail { get; private set; }
        public DoublyLinkedList PreviousNode { get; private set; }
        public DoublyLinkedList NextNode { get; private set; }
        public int Length { get; private set; }
        public int Position { get; private set; }
        public string Value { get; set; }

        public DoublyLinkedList Append(string value)
        {
            var newNode = new DoublyLinkedList(value)
            {
                Head = Head
            };
            Append(newNode);
            return this;
        }

        private void Append(DoublyLinkedList node)
        {
            Length++;
            Tail = node;
            if (NextNode == null)
            {
                node.Length = node.Position = Length;
                node.Tail = node;
                node.PreviousNode = this;
                NextNode = node;
                return;
            }
            NextNode.Append(node);
        }

        public DoublyLinkedList GetNodeAt(int position)
        {
            if (Position == position)
            {
                return this;
            }
            return NextNode.GetNodeAt(position);
        }
    
    }
}