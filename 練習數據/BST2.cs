using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 練習數據
{
    class BST2<Key,Value>where Key:IComparable<Key>
    {
        private class Node
        {
            public Key key;
            public Value value;
            public Node left;
            public Node right;
            public Node(Key key,Value value,Node next)
            {
                this.key = key;
                this.value = value;
                this.left = null;
                this.right = null;               
            }
            public Node(Key key,Value value) : this(key,value,null)
            {

            }
            public override string ToString()
            {
                return $"{key}-{value}";
            }
        }
        private int N;
        private Node root;

        public BST2()
        {
            this.root = null;
            this.N = 0;
        }
        public int Count { get { return N; } }
        public bool IsEmpty { get { return N == 0; } }
    
        public void Add(Key key,Value value)
        {

        }
        private Node Add(Node node,Key key,Value value)
        {
            if (node == null)
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
            return node;
        }
        public Value Min()
        {
            if (IsEmpty)
                throw new InvalidOperationException("空樹~");
            return Min(this.root).value;
        }
        private Node Min(Node node)
        {
            if (node.left == null)
                return node;
            return Min(node.left);
        }
        public void RemoveMin()
        {
            this.root = RemoveMin(this.root);
        }
        private Node RemoveMin(Node node)
        {
            if (node.left == null)
                return node.right;
            node.left = RemoveMin(node.left);
            return node;
        }
        public void Remove(Key key)
        {
            this.root = Remove(this.root, key);
        }
        private Node Remove(Node node,Key key)
        {
            if (node == null)
                return null;
            if(key.CompareTo(node.key)<0)
            {
                node.left = Remove(node.left, key);
                return node;
            }
            else if(key.CompareTo(node.key)>0)
            {
                node.right = Remove(node.right, key);
                return node;
            }
            else // key.CompareTo(node.key)==0
            {
                N--;
                if (node.left == null)
                    return node.right;
                else if (node.right == null)
                    return node.left;
                else
                {
                    Node x = Min(node.right);
                    x.right = RemoveMin(node.right);
                    x.left = node.left;
                    return x;
                }
            }
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
        public Value Get(Key key)
        {
            Node node = GetNode(this.root, key);
            if (node == null)
                throw new ArgumentException("非法索引");
            return node.value;
        }
        public void Set(Key key,Value newValue)
        {
            Node node = GetNode(this.root, key);
            if (node == null)
                throw new ArgumentException("非法索引");
            node.value = newValue;
        }
        public bool Contains(Key key)
        {
            Node node = GetNode(this.root,key);
            return node != null;
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
    }
}
