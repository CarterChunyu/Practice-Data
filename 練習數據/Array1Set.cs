using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 練習數據
{
    class Array1Set<E>:ISet<E>
    {
        private Array1<E> array1;
        public Array1Set()
        {
            array1 = new Array1<E>();
        }

        public bool IsEmpty { get { return array1.IsEmpty; } }

        public int Count { get { return array1.Count;  } }

        public void Add(E e)
        {
            if (!array1.Contains(e))
            {
                array1.AddLast(e);
            }
        }
        public bool Contains(E e)
        {
            return array1.Contains(e);
        }

        public void Remove(E e)
        {
            array1.Remove(e);
        }
    }
}
