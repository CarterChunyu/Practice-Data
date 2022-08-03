using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 練習數據
{
    class Array1Stack<E>:IStack<E>
    {
        private Array1<E> array1;
        public Array1Stack()
        {
            this.array1 = new Array1<E>();
        }
        public Array1Stack(int capacity)
        {
            this.array1 = new Array1<E>(capacity);
        }

        public int Count()
        {
            return array1.Count;
        }

        public bool IsEmpty()
        {
            return array1.IsEmpty;
        }

        public E Peek()
        {
            return array1.GetLast();
        }

        public E Pop()
        {
            E e = array1.GetLast();
            this.array1.RemoveLast();
            return e;
        }

        public void Push(E e)
        {
            this.array1.AddLast(e);
        }
    }
}
