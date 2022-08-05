using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 練習數據
{
    class RBT1Set<E> : ISet<E> where E : IComparable<E>
    {
        private RBT1<E> rBT1;
        public RBT1Set() 
        {
            rBT1 = new RBT1<E>();    
        }

        public bool IsEmpty { get { return rBT1.IsEmpty; } }

        public int Count { get { return rBT1.Count; } }

        public void Add(E e)
        {
            rBT1.Add(e);
        }

        public bool Contains(E e)
        {
            return rBT1.Contains(e);
        }

        public void Remove(E e)
        {
            Console.WriteLine("未實作");
        }
    }
}
