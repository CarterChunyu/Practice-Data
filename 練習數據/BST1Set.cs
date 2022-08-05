using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 練習數據
{
    class BST1Set<E>:ISet<E>where E:IComparable<E>
    {
        private BST1<E> bST1;
        public BST1Set()
        {
            bST1 = new BST1<E>();
        }

        public bool IsEmpty { get { return bST1.IsEmpty; } }

        public int Count { get { return bST1.Count; } }

        public void Add(E e)
        {
            bST1.Add(e);
        }

        public bool Contains(E e)
        {
            return bST1.Contains(e);
        }

        public void Remove(E e)
        {
            throw new NotImplementedException();
        }
    }
}
