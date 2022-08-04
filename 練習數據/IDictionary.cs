using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 練習數據
{
    interface IDictionary<Key,Value>
    {
        void Add(Key key, Value value);
        void Remove(Key key);
        bool Contains(Key key);
        Value Get(Key key);
        void Set(Key key, Value newValue);
        int Count { get; }
        bool IsEmpty { get; }
    }
}
