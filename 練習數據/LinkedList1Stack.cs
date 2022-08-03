using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 練習數據
{
    class LinkedList1Stack<E>:IStack<E>
    {
        private LinkedList1<E> linkedList1;
        public LinkedList1Stack()
        {
            linkedList1 = new LinkedList1<E>();
        }

        public int Count()
        {
            return linkedList1.Count;
        }

        public bool IsEmpty()
        {
            return linkedList1.IsEmpty;
        }

        public E Peek()
        {
            return linkedList1.GetFirst();
        }

        public E Pop()
        {
            return linkedList1.RemoveFirst();
        }

        public void Push(E e)
        {
            linkedList1.AddFirst(e);
        }
    }
}
