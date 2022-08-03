using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 練習數據
{
    class LinkedList1<E>
    {
        private class Node
        {
            public E e;
            public Node next;

            public Node(E e,Node next)
            {
                this.e = e;
                this.next = next;
            }
            public Node(E e) : this(e, null)
            {

            }
            public override string ToString()
            {
                return e.ToString();
            }
        }
        private Node head;
        private int N;

        public int Count { get { return N; } }
        public bool IsEmpty { get { return N == 0; } }
        public LinkedList1()
        {
            this.head = null;
            this.N = 0;
        }
        public void Add(int index,E e)
        {
            if (index < 0 || index > N)
                throw new ArgumentException("非法索引");
            N++;
            if(index==0)
            {
                //Node node = new Node(e);
                //node.next = this.head;
                //this.head = node;
                this.head = new Node(e, this.head);
            }
            else
            {
                Node pre = this.head;
                for (int i = 0; i < index - 1; i++)
                    pre = pre.next;
                //Node node = new Node(e);
                //node.next = pre.next;
                //pre.next = node;
                pre.next = new Node(e, pre.next);
            }
        }
        public void AddFirst(E e)
        {
            this.Add(0, e);
        }
        public void AddLast(E e)
        {
            this.Add(N, e);
        }
        public E RemoveAt(int index)
        {
            if (index < 0 || index >= N)
                throw new ArgumentException("非法索引");
            N--;
            if (index == 0)
            {
                Node del = this.head;
                this.head = this.head.next;
                return del.e;
            }                
            else
            {
                Node pre = this.head;
                for (int i = 0; i < index - 1; i++)
                    pre = pre.next;
                Node del = pre.next;
                pre.next = pre.next.next;
                return del.e;
            }
        }
        public E RemoveFirst()
        {
            return RemoveAt(0);
        }
        public E RemoveLast()
        {
            return RemoveAt(N - 1);
        }
        public void Remove(E e)
        {
            if (this.N == 0)
                return;
            if(this.head.e.Equals(e))
            {
                N--;
                this.head = this.head.next;
            }
            else
            {
                Node pre = null;
                Node cur = this.head;
                while (cur != null)
                {
                    if (cur.e.Equals(e))
                        break;
                    pre = cur;
                    cur = cur.next;
                }
                if (cur != null)
                {
                    N--;
                    pre.next = pre.next.next;
                }
            }
        }
        public void Remove1(E e)
        {
            Node pre = null;
            Node cur = this.head;
            while (cur != null)
            {
                if (e.Equals(cur.e))
                {
                    N--;
                    if (pre == null)
                        this.head = this.head.next;
                    else
                        pre.next = pre.next.next;
                    break;
                }
                pre = cur;
                cur = cur.next;
            }
        }
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            Node cur = this.head;
            while (cur != null)
            {
                builder.Append($"{cur}=>");
                cur = cur.next;
            }
            builder.Append("Null");
            return builder.ToString();
        }
        public bool Contains(E e)
        {
            Node cur = this.head;
            while (cur != null)
            {
                if (e.Equals(cur.e))
                    return true;
                cur = cur.next;
            }
            return false;
        }
        public E Get(int index)
        {
            if (index < 0 || index >= N)
                throw new ArgumentException("非法索引");
            Node cur = this.head;
            for (int i = 0; i < index; i++)
                cur = cur.next;
            return cur.e;
        }
        public E GetFirst()
        {
            return Get(0);
        }
        public E GetLast()
        {
            return Get(N - 1);
        }

        public void Set(int index,E newE)
        {
            if (index < 0 || index > N)
                throw new ArgumentException("非法索引");
            Node cur = this.head;
            for (int i = 0; i < index; i++)
                cur = cur.next;
            cur.e = newE;           
        }
    }
}
