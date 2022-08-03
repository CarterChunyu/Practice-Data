using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 練習數據
{
    class RBT1<E> where E:IComparable<E>
    {
        private const bool Red = true;
        private const bool Black = false;
        private class Node
        {
            public E e;
            public Node left;
            public Node right;
            public bool Color;
            public Node(E e)
            {
                this.e = e;
                left = null;
                right = null;
                Color = Red;
            }
            public override string ToString()
            {
                return e.ToString();
            }
        }
        private int N;
        private Node root;
        public int Count { get { return N; } }
        public bool IsEmpty { get { return N == 0; } }

        public RBT1()
        {
            this.N = 0;
            this.root = null;
        }
        private bool IsRed(Node node)
        {
            if (node == null)
                return Black;
            return node.Color;
        }
        private Node LeftRotate(Node node)
        {
            Node x = node.right;
            node.right = x.left;
            x.left = node;
            x.Color = node.Color;
            node.Color = Red;
            return x;
        }
        private Node RightRotate(Node node)
        {
            Node x = node.left;
            node.left = x.right;
            x.right = node;
            x.Color = node.Color;
            node.Color = Red;
            return node;
        }
        private void FlipColor(Node node)
        {
            node.Color = Red;
            node.left.Color = Black;
            node.right.Color = Black;
        }

        public void Add(E e)
        {
            
        }
        private Node Add(Node node,E e)
        {
            if(node==null)
            {
                N++;
                return new Node(e);
            }
            if (e.CompareTo(node.e) < 0)
                node.left = Add(node.left, e);
            else if (e.CompareTo(node.e) > 0)
                node.right = Add(node.right, e);
            if (!IsRed(node.left) && IsRed(node.right))
                node = LeftRotate(node);
            if (IsRed(node.left) && IsRed(node.left.left))
                node = RightRotate(node);
            if (IsRed(node.left) && IsRed(node.right))
                FlipColor(node);
            return node;
        }
        public int MaxHeight()
        {
            return MaxHeight(this.root);
        }
        private int MaxHeight(Node node)
        {
            if (node == null)
                return 0;
            else
            {
                int l = MaxHeight(node.left);
                int r = MaxHeight(node.right);
                return Math.Max(l, r) + 1;
            }
        }
        public bool Contains(E e)
        {
            return Contains(this.root, e);
        }
        private bool Contains(Node node,E e)
        {
            if (node == null)
                return false;
            if (e.CompareTo(node.e) == 0)
                return true;
            else if (e.CompareTo(node.e) < 0)
                return Contains(node.left, e);
            else //e.CompareTo(node.e)>0
                return Contains(node.right, e);
        }
        public void InOrder()
        {
            InOrder(this.root);
        }
        private void InOrder(Node node)
        {
            if (node == null)
                return;
            InOrder(node.left);
            Console.WriteLine(node);
            InOrder(node.right);
        }
    }
}
