using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 練習數據
{
    class Array1Queue<E>:IQueue<E>
    {
        private Array1<E> array1;
        public Array1Queue()
        {
            array1 = new Array1<E>();
        }

        public int Count { get { return array1.Count; } }

        public bool IsEmpty { get { return array1.IsEmpty; } }

        public E Dequeue()
        {
            return array1.RemoveFirst();
        }

        public void Enqueue(E e)
        {
            this.array1.AddLast(e);
        }

        public E Peek()
        {
            return array1.GetFirst();
        }
    }
}
