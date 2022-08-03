using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 練習數據
{
    class HashSt1<Key>
    {
        private LinkedList1<Key>[] hashtable;
        private int N;
        private int M;

        public HashSt1(int M)
        {
            this.hashtable = new LinkedList1<Key>[M];
            this.M = M;
            this.N = 0;
        }
        public HashSt1() : this(97)
        {

        }
        private int Hash(Key key)
        {
           return (key.GetHashCode() & 0x7fffffff) % M;
        }
        public void Add(Key key)
        {
            int index = Hash(key);
            LinkedList1<Key> l= this.hashtable[index];
            if (!l.Contains(key))
            {
                l.AddFirst(key);
                N++;
            }
        }
        public void Remove(Key key)
        {
            LinkedList1<Key> l = this.hashtable[Hash(key)];
            if (l.Contains(key))
            {
                l.Remove(key);
                N--;
            }
        }
        public bool Contains(Key key)
        {
            LinkedList1<Key> l = this.hashtable[Hash(key)];
            return l.Contains(key);
        }
    }
}
