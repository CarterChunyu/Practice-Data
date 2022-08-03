using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 練習數據
{
    class Array2Queue<E>:IQueue<E>
    {
        private Array2<E> array2;

        public int Count { get { return array2.Count; } }
        public bool IsEmpty { get { return array2.IsEmpty; } }

        public Array2Queue(int capacity)
        {
            array2 = new Array2<E>(capacity);
        }
        public Array2Queue()
        {
            array2 = new Array2<E>();
        }

        public void Enqueue(E e)
        {
            array2.AddLast(e);
        }

        public E Dequeue()
        {
            return array2.RemoveFirst();
        }

        public E Peek()
        {
            return array2.GetFirst();
        }
    }
}
