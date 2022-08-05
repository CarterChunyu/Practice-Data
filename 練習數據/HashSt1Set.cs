using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 練習數據
{
    class HashSt1Set<Key> : ISet<Key>
    {
        private HashSt1<Key> hashSt1;
        public HashSt1Set()
        {
            hashSt1 = new HashSt1<Key>();
        }
        public bool IsEmpty { get { return hashSt1.IsEmpty; } }

        public int Count { get { return hashSt1.Count; } }

        public void Add(Key e)
        {
            hashSt1.Add(e);
        }

        public bool Contains(Key e)
        {
           return hashSt1.Contains(e);
        }

        public void Remove(Key e)
        {
            hashSt1.Remove(e);
        }
    }
}
