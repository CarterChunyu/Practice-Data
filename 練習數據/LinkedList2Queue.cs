using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 練習數據
{
    class LinkedList2Queue<E>:IQueue<E>
    {
        private LinkedList2<E> linkedList2;
        public LinkedList2Queue()
        {
            linkedList2 = new LinkedList2<E>();
        }

        public int Count { get { return linkedList2.Count; } }

        public bool IsEmpty { get { return linkedList2.IsEmpty; } }

        public E Dequeue()
        {
            return linkedList2.RemoveFirst();
        }

        public void Enqueue(E e)
        {
            linkedList2.AddLast(e);
        }

        public E Peek()
        {
            return linkedList2.GetFirst();
        }
    }
}
