using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 練習數據
{
    interface ISet<E>
    {
        bool IsEmpty { get; }
        int Count { get; }
        void Add(E e);
        void Remove(E e);
        bool Contains(E e);
    }
}
