using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 練習數據
{
    class Array1<E>
    {
        private E[] data;
        private int N;

        public int Count { get { return N; } }
        public bool IsEmpty { get { return N == 0; } }
        public Array1(int capacity)
        {
            this.data = new E[capacity];
            this.N = 0;
        }
        public Array1():this(10)
        {
            
        }
        public void Add(int index,E e)
        {
            if (index < 0 || index > N) // 希望緊密排列
                throw new ArgumentException("非法索引");
            if (N == data.Length)
                ResetCapacity(2 * data.Length);
            for (int i = N - 1; i >= index; i--)
                data[i + 1] = data[i];
            data[index] = e;
            N++;
        }
        public void  AddFirst(E e)
        {
            this.Add(0, e);
        }
        public void AddLast(E e)
        {
            this.Add(N, e);
        }
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"N {this.N}, capacity: {this.data.Length}");
            for (int i = 0; i < N; i++)
            {
                builder.Append(this.data[i]);
                if (i < N - 1)
                    builder.Append(", ");
            }
            return builder.ToString();
        }
        public E RemoveAt(int index)
        {
            if (index < 0 || index >= N)
                throw new ArgumentException("非法索引");            
            E e = data[index];
            for (int i = index; i < N - 1; i++)
                data[i] = data[i + 1];
            data[N - 1] = default(E);
            N--;
            if (N == this.data.Length / 4)
                ResetCapacity(this.data.Length / 2);
            return e;
        }
        public E RemoveFirst()
        {
            return RemoveAt(0);
        }
        public E RemoveLast()
        {
            return RemoveAt(N - 1);
        }
        public void Remove(E e)
        {
            int index = -1;
            for (int i = 0; i < N; i++)
            {
                if (this.data[i].Equals(e))
                    index = i;
            }
            if (index != -1)
            {
                for (int i = index; i < N - 1; i++)
                    this.data[i] = this.data[i + 1];
                data[index] = default(E);
                N--;
                if (N == this.data.Length / 4)
                    ResetCapacity(this.data.Length / 2);
            }                     
        }
        public bool Contains(E e)
        {
            for (int i = 0; i < N; i++)
            {
                if (this.data[i].Equals(e))
                    return true;
            }
            return false;
        }
        public E Get(int index)
        {
            if (index < 0 || index >= N)
                throw new ArgumentException("非法索引");
            return this.data[index];
        }
        public E GetFirst()
        {
            return Get(0);
        }
        public E GetLast()
        {
            return Get(N - 1);
        }
        public E Set(int index,E newE)
        {
            if (index < 0 || index >= N)
                throw new ArgumentException("非法索引");
            return this.data[index] = newE;
        }
        private void ResetCapacity(int capacity)
        {
            E[] newData = new E[capacity];
            for (int i = 0; i < N; i++)
            {
                newData[i] = data[i];
            }
            this.data = newData;
        }
    }
}
