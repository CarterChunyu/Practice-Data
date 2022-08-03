using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 練習數據
{
    interface IQueue<E>
    {
        void Enqueue(E e);
        E Dequeue();
        E Peek();
        int Count { get; }
        bool IsEmpty { get; }
        

    }
}
