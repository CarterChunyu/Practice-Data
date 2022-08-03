using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 練習數據
{
    class BST1<E> where E:IComparable<E>
    {
        private class Node
        {
            public E e;
            public Node left;
            public Node right;
            public Node(E e)
            {
                this.e=e;
                this.left = null;
                this.right = null;
            }
            public override string ToString()
            {
                return e.ToString();
            }
        }
        private int N;
        private Node root;

        public BST1()
        {
            this.N = 0;
            this.root = null;
        }
        public int Count { get { return N; } }
        public bool IsEmpty { get { return N == 0; } }
        public void Add(E e)
        {
            this.root = Add(this.root, e);
        }
        private Node Add(Node node,E e)
        {
            if (node == null)
            {
                N++;
                return new Node(e);
            }
            if (e.CompareTo(node.e) < 0)
                node.left = Add(node.left, e);
            else if (e.CompareTo(node.e) > 0)
                node.right = Add(node.right, e);
            return node;
        }
        public E GetMin()
        {
            if (IsEmpty)
                throw new InvalidOperationException("空樹");
            return GetMin(this.root).e;
        }
        private Node GetMin(Node node)
        {
            if (node.left == null)
                return node;
            return GetMin(node.left);
        }
        public E GetMax()
        {
            if (IsEmpty)
                throw new InvalidCastException("空樹 ");
            return GetMax(this.root).e;
        }
        private Node GetMax(Node node)
        {
            if (node.right == null)
                return node;
            return GetMax(node.right);
        }
        public void RemoveMin()
        {
            if (IsEmpty)
                throw new InvalidOperationException("空樹");
            this.root = RemoveMin(this.root);            
        }
        private Node RemoveMin(Node node)
        {
            if (node.left == null)
            {
                N--;
                return node.right;
            }
            node.left = RemoveMin(node.left);
            return node;
        }
        public void RemoveMax()
        {
            if (IsEmpty)
                throw new InvalidOperationException("空樹");
            this.root = RemoveMax(this.root);
        }
        private Node RemoveMax(Node node)
        {
            if (node.right == null)
            {
                N--; 
                return node.left;
            }
            node.right = RemoveMax(node.right);
            return node;

        }

        public void Remove(E e)
        {
            this.root = Remove(this.root,e);
        }
        private Node Remove(Node node, E e)
        {
            if (node == null)
                return null;
            if (e.CompareTo(node.e) < 0)
            {
                node.left = Remove(node, e);
                return node;
            }
            else if (e.CompareTo(node.e) > 0)
            {
                node.right = Remove(node.right, e);
                return node;
            }
            else //e.CompareTo(node.e)==0
            {
                N--;
                if (node.left == null)
                    return node.right;
                if (node.right == null)
                    return node.left;
                Node x = GetMin(node.right);
                x.right = RemoveMin(node.right);
                x.left = node.left;
                return x;
            }
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
        public void LevelOrder()
        {
            Queue<Node> q = new Queue<Node>();
            if (this.root != null)
                q.Enqueue(this.root);
            while (q.Count > 0)
            {
                Node node = q.Dequeue();
                if (node.left != null)
                    q.Enqueue(node.left);
                if (node.right != null)
                    q.Enqueue(node.right);
            }
        }
        public int MaxHeight()
        {
            return MaxHeight(this.root);
        }
        private int MaxHeight(Node node)
        {
            if (node == null)
                return 0;
            int l = MaxHeight(node.left);
            int r = MaxHeight(node.right);
            return Math.Max(l, r) + 1;
        }
        // 在 e前面的不包含 e有幾個, e的索引 
        public int Rank(E e)
        {
            return Rank(this.root, e);
        }
        private int Rank(Node node,E e)
        {
            if (node == null)
                return 0;
            if (e.CompareTo(node.e) <= 0)
                return Rank(node.left, e);
            else
            {
                int l = Rank(node.left, e);
                int r = Rank(node.right, e);
                return l + r + 1;
            }
        }
        public E Ceiling(E e)
        {
            Node c = Ceiling(this.root,e);
            if (c == null)
                throw new ArgumentException("非法參數");
            return c.e;
        }
        private Node Ceiling(Node node,E e)
        {
            if (node == null)
                return null;
            if (e.CompareTo(node.e) == 0)
                return node;
            else if (e.CompareTo(node.e) > 0)
                return Ceiling(node.right,e);
            else //(e.CompareTo(node.e)<0)
            {
                Node l = Ceiling(node.left, e);
                return l != null ? l : node;
            }
        }
        public E Floor(E e)
        {
            Node f = Floor(this.root,  e);
            if (f == null)
                throw new ArgumentException("非法參數");
            return f.e;
        }
        private Node Floor(Node node,E e)
        {
            if (node == null)
                return null;
            if (e.CompareTo(node.e) == 0)
                return node;
            else if (e.CompareTo(node.e) < 0)
                return Floor(node.left, e);
            else // e.CompareTo(node.e)>0
            {
                Node r = Floor(node.right, e);
                return r != null ? r : node;
            }
        }
        //public E Select(int index)
        //{
        //    if (index < 0 || index >= N)
        //        throw new ArgumentException("非法索引");
        //    return Select(index, this.root).e;
        //}
        //private Node Select(int index,Node node)
        //{
        //    int r = Rank(node.e);
        //    if (r == index)
        //        return node;
        //    else if (r > index)
        //        return Select(index, node.right);
        //    else //r<index
        //        return Select(index, node.left);
        //}


        public E Select(int index)
        {
            if (index < 0 || index >= N)
                throw new ArgumentException("非法索引");
            return Select(index, this.root).e;
        }
        private Node Select(int index,Node node)
        {
            int r = Rank(node.e);
            if (r == index)
                return node;
            else if (index<r)
                return Select(index, node.left);
            else
                return Select(index, node.right);
        }
    }
}
