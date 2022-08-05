using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 練習數據
{
    class SortedArray2Dicitonary<Key, Value> : IDictionary<Key, Value> where Key:IComparable<Key>
    {
        private SortedArray2<Key, Value> sortedArray2;
        public SortedArray2Dicitonary(int capacity)
        {
            this.sortedArray2 = new SortedArray2<Key, Value>(capacity);
        }
        public SortedArray2Dicitonary()
        {
            this.sortedArray2 = new SortedArray2<Key, Value>();
        }
        public int Count { get { return sortedArray2.Count; } }

        public bool IsEmpty { get { return sortedArray2.IsEmpty; } }

        public void Add(Key key, Value value)
        {
            this.sortedArray2.Add(key, value);
        }

        public bool Contains(Key key)
        {
            return sortedArray2.Contains(key);
        }

        public Value Get(Key key)
        {
            return sortedArray2.Get(key);
        }

        public void Remove(Key key)
        {
            this.sortedArray2.Remove(key);
        }

        public void Set(Key key, Value newValue)
        {
            this.sortedArray2.Set(key,newValue);
        }
    }
}
