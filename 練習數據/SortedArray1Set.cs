using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 練習數據
{
    class SortedArray1Set<E>:ISet<E> where E:IComparable<E>
    {
        private SortedArray1<E> sortedArray1;

        public bool IsEmpty { get { return sortedArray1.IsEmpty; } }

        public int Count { get { return sortedArray1.Count; } }

        // private int n
        public SortedArray1Set(int capacity)
        {
            sortedArray1 = new SortedArray1<E>(capacity);
        }
        public SortedArray1Set()
        {
            sortedArray1 = new SortedArray1<E>();
        }

        public void Add(E e)
        {
            sortedArray1.Add(e);
        }

        public void Remove(E e)
        {
            sortedArray1.Remove(e);
        }

        public bool Contains(E e)
        {
            return sortedArray1.Contains(e);
        }
    }
}
