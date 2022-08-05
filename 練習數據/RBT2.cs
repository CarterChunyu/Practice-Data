using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 練習數據
{
    class RBT2<Key,Value>where Key:IComparable<Key>
    {
        private const bool Red = true;
        private const bool Black = false;
        private class Node
        {
            public Key key;
            public Value value;
            public bool Color;
            public Node left;
            public Node right;

            public Node(Key key,Value value)
            {
                this.key = key;
                this.value = value;
                this.left = null;
                this.right = null;
                this.Color = Red;
            }
            public override string ToString()
            {
                return $"{this.key}:{this.value}";
            }
        }
        private int N;
        private Node root;
        public RBT2()
        {
            this.N = 0;
            this.root = null;
        }
        public int Count { get { return N; } }
        public bool IsEmpty { get { return N == 0; } }
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
            return x;
        }
        private void FlipColor(Node node)
        {
            node.Color = Red;
            node.left.Color = Black;
            node.right.Color = Black;
        }
        public void Add(Key key,Value value)
        {
            this.root = Add(this.root, key, value);
        }
        private Node Add(Node node,Key key,Value value)
        {
            if(node==null)
            {
                N++;
                return new Node(key, value);
            }
            if (key.CompareTo(node.key) < 0)
                node.left = Add(node.left, key, value);
            else if (key.CompareTo(node.key) > 0)
                node.right = Add(node.right, key, value);
            else // key.CompareTo(node.key)==0
                node.value = value;
            if (!IsRed(node) && IsRed(node.right))
                node = LeftRotate(node);
            if (IsRed(node.left) && IsRed(node.left.left))
                node = RightRotate(node);
            if (IsRed(node.left) && IsRed(node.right))
                FlipColor(node);
            return node;
        }
        private Node GetNode(Node node,Key key)
        {
            if (node == null)
                return null;
            if (key.CompareTo(node.key) < 0)
                return GetNode(node.left, key);
            else if (key.CompareTo(node.key) > 0)
                return GetNode(node.right, key);
            else // key.CompareTo(node.key)==0
                return node;
        }
        public bool Contains(Key key)
        {
            Node node = GetNode(this.root,key);
            return node != null;
        }
        public Value Get(Key key)
        {
            Node node = GetNode(this.root, key);
            if (node == null)
                throw new ArgumentException("無此鍵");
            return node.value;
        }
        public void Set(Key key,Value newValue)
        {
            Node node = GetNode(this.root, key);
            if (node == null)
                throw new ArgumentException("無此鍵");
            node.value = newValue;
        }
    }
}
