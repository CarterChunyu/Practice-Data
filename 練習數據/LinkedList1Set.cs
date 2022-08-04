using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 練習數據
{
    class LinkedList1Set<E>:ISet<E>
    {
        private LinkedList1<E> linkedList1;
        public LinkedList1Set()
        {
            linkedList1 = new LinkedList1<E>();
        }

        public bool IsEmpty { get { return linkedList1.IsEmpty; } }

        public int Count { get { return linkedList1.Count; } }

        public void Add(E e)
        {
            if (!linkedList1.Contains(e))
            {
                linkedList1.AddFirst(e);
            }
        }

        public bool Contains(E e)
        {
            return linkedList1.Contains(e);
        }

        public void Remove(E e)
        {
            linkedList1.Remove(e);
        }
    }
}
