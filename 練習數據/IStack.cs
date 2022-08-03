using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 練習數據
{
    interface IStack<E>
    {
        void Push(E e);
        E Pop();
        E Peek();
        int Count();
        bool IsEmpty();
    }
}
