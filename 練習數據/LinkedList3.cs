using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 練習數據
{
    class LinkedList3<Key,Value>
    {
        private class Node
        {
            public Key key;
            public Value value;
            public Node next;
            public Node(Key key,Value value)
            {
                this.key = key;
                this.value = value;
                this.next = null;
            }
            public override string ToString()
            {
                return $"{key}-{value}";
            }
        }
        private int N;
        private Node head;

        public int Count { get { return N; } }
        public bool IsEmpty { get { return N == 0; } }

        public LinkedList3()
        {
            this.N = 0;
            this.head = null;
        }
        private Node GetNode(Key key)
        {
            Node cur = this.head;
            while (cur != null)
            {
                if (key.Equals(cur.key))
                    return cur;
                cur = cur.next;
            }
            return null;
        }
        public Value Get(Key key)
        {
            Node node = GetNode(key);
            if (node == null)
                throw new InvalidOperationException("鍵不存在");
            return node.value;
        }
        public void Set(Key key,Value newValue)
        {
            Node node = GetNode(key);
            if (node == null)
                throw new InvalidOperationException("鍵不存在");
            node.value = newValue;
        }
        public void Add(Key key,Value value)
        {
            Node node = GetNode(key);
            if (node != null)
                node.value = value;
            else
            {
                Node newNode = new Node(key, value);
                newNode.next = this.head;
                this.head = newNode;
                N++;
            }
        }
        public void Remove(Key key)
        {
            if (IsEmpty)
                return;
            if (key.Equals(this.head.key))
            {
                this.head = this.head.next;
                N--;
            }
            else
            {
                Node pre = null;
                Node cur = this.head;
                while (cur != null)
                {
                    if (key.Equals(cur.key))
                        break;
                    pre = cur;
                    cur = cur.next;
                }
                if (cur != null)
                {
                    pre.next = pre.next.next;
                    N--;
                }
            }
        }
        public bool Contains(Key key)
        {
            return GetNode(key) != null;
        }
    }
}
