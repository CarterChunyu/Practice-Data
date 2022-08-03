using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 練習數據
{
    class Array2<E>
    {
        private E[] data;
        private int N;
        private int first;
        private int last;

        public Array2(int capacity)
        {
            this.data = new E[capacity];
            this.N = 0;
            this.first = 0;
            this.last = 0;
        }
        public Array2() : this(10)
        {

        }
        public int Count { get { return N; } }
        public bool IsEmpty { get { return N == 0; } }

        public void AddLast(E e)
        {
            if (N == data.Length)
            {
                ResetCapacity(2 * data.Length);
            }
            data[last] = e;
            last = (last + 1) % data.Length;
            N++;
        }
        public E RemoveFirst()
        {
            if (IsEmpty)
                throw new InvalidOperationException("空樹");
            E e = data[first];
            data[first] = default(E);
            first = (first + 1) % data.Length;
            N--;
            if (N == data.Length / 4)
                ResetCapacity(this.data.Length / 2);
            return e;
        }
        public E GetFirst()
        {
            if (IsEmpty)
                throw new InvalidOperationException("空樹");
            return data[first];
        }
        //private void ResetCapacity(int capacity)
        //{
        //    E[] newData = new E[capacity];
        //    for (int i = 0; i < N; i++)
        //    {
        //        newData[i] = data[first];
        //        first = (first + 1) % data.Length;
        //    }
        //    this.data = newData;
        //}
        private void ResetCapacity(int capacity)
        {
            E[] newData = new E[capacity];
            for (int i = 0; i < N; i++)
                newData[i] = data[(first + i) % data.Length];
            first = 0;
            last = N;
            this.data = newData;
        }
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append($"capacity : {data.Length}, count {N}");
            builder.Append("head");
            for (int i = 0; i < N; i++)
            {
                builder.Append(data[(first + i) % data.Length]);
                if (first + i + 1 != last)
                    builder.Append($", ");
            }
            builder.Append("tail");
            return builder.ToString();
        }
    }
}
