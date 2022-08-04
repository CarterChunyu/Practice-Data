using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 練習數據
{
    class LinkedList3Dictionary<Key,Value>:IDictionary<Key,Value>
    {
        private LinkedList3<Key, Value> linkedList3;
        public LinkedList3Dictionary()
        {
            linkedList3 = new LinkedList3<Key, Value>();
        }

        public int Count { get { return linkedList3.Count ; } }

        public bool IsEmpty { get { return linkedList3.IsEmpty; } }

        public void Add(Key key, Value value)
        {
            linkedList3.Add(key, value);
        }

        public bool Contains(Key key)
        {
            return linkedList3.Contains(key);
        }

        public Value Get(Key key)
        {
            return linkedList3.Get(key);
        }

        public void Remove(Key key)
        {
            linkedList3.Remove(key);
        }

        public void Set(Key key, Value newValue)
        {
            linkedList3.Set(key, newValue);
        }
    }
}
