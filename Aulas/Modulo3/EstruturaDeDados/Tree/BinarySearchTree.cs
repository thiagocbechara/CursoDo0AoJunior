using System;

namespace CursoDo0AoJunior.Modulo3.EstruturaDeDados.Tree
{
    public class BinarySearchTree
    {
        public BinarySearchTree(decimal value)
        {
            this.Value = value;
        }

        public decimal Value { get; private set; }
        public BinarySearchTree LeftNode { get; private set; }
        public BinarySearchTree RightNode { get; private set; }

        public BinarySearchTree AddValue(decimal value)
        {
            if (value < this.Value) { AddLeftNode(value); }
            if (value > this.Value) { AddRightNode(value); }
            return this;
        }

        private void AddLeftNode(decimal value)
        {
            if (LeftNode != null) { LeftNode.AddValue(value); }
            LeftNode = new BinarySearchTree(value);
        }

        private void AddRightNode(decimal value)
        {
            if (RightNode != null) { RightNode.AddValue(value); }
            RightNode = new BinarySearchTree(value);
        }
    }
}