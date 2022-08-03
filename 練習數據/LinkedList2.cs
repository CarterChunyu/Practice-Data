using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 練習數據
{
    class LinkedList2<E>
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
            public Node (E e) : this(e, null)
            {

            }
            public override string ToString()
            {
                return e.ToString();
            }
        }
        private int N;
        private Node head;
        private Node tail;

        public int Count { get { return N; } }
        public bool IsEmpty { get { return N == 0; } }
        public LinkedList2()
        {
            this.N = 0;
            head = null;
            tail = null;
        }
        public void AddLast(E e)
        {
            N++;
            Node node = new Node(e);
            if (this.tail == null)
            {
                this.head = node;
                this.tail = node;
            }
            else
            {
                this.tail.next = node;
                this.tail = node;
            }
        }
        //public E RemoveFirst()
        //{
        //    if (IsEmpty)
        //        throw new InvalidOperationException("非法索引");
        //    N--;
        //    if(N==1)
        //    {
        //        Node del = this.head;
        //        this.head = null;
        //        this.tail = null;
        //        return del.e;
        //    }
        //    else
        //    {
        //        Node del = this.head;
        //        this.head = this.head.next;
        //        return del.e;
        //    }
        //}

        public E RemoveFirst()
        {
            if (IsEmpty)
                throw new InvalidOperationException("空樹");
            Node del = this.head;
            this.head = this.head.next;
            N--;
            if (N == 0)
                this.tail = null;
            return del.e;
        }


        public E GetFirst()
        {
            if (IsEmpty)
                throw new InvalidOperationException("空樹");
            return this.head.e;
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
            builder.Append("null");
            return builder.ToString();
        }
    }
}
