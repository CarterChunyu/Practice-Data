using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 練習數據
{
    class SortedArray1<Key> where Key:IComparable<Key>
    {
        private Key[] keys;
        private int N;

        public int Count { get { return N; } }
        public bool IsEmpty { get { return N == 0; } }

        public SortedArray1(int capacity)
        {
            this.keys = new Key[capacity];
            this.N = 0;
        }
        public SortedArray1() : this(10)
        {

        }
        public int Rank(Key key)
        {
            int l = 0;
            int r = N-1;
            while (l <= r)
            {
                int mid = (r - l) / 2 + l;
                if (key.CompareTo(keys[mid]) < 0)
                    r = mid - 1;
                else if (key.CompareTo(keys[mid]) > 0)
                    l = mid + 1;
                else // key.CompareTo(data[mid])==0
                    return mid;
            }
            return l;
        }
        private void ResetCapacity(int capacity)
        {
            Key[] newKeys = new Key[capacity];
            for (int i = 0; i < N; i++)
                newKeys[i] = keys[i];
            this.keys = newKeys; 
        }
        public void Add(Key key)
        {
            int index = Rank(key);
            if (index < N && key.CompareTo(keys[index]) == 0)
                return;
            if (N == this.keys.Length)
                ResetCapacity(2 * keys.Length);
            for (int i = N - 1; i >= index;i--)
                keys[i + 1] = keys[i];
            keys[index] = key;
            N++;
        }
        public void Remove(Key key)
        {
            int index = Rank(key);
            //if(index<N&&key.CompareTo(keys[index])==0)
            //{
            //    for (int i = index; i < N - 1; i++)
            //        keys[i] = keys[i + 1];
            //    keys[N - 1] = default(Key);
            //    N--;
            //    if (N == this.keys.Length / 4)
            //        ResetCapacity(keys.Length / 2);
            //}
            if (index == N || key.CompareTo(keys[index]) != 0)
                return;
            for (int i = index; i < N - 1; i++)
                keys[i] = keys[i + 1];
            keys[N - 1] = default(Key);
            N--;
            if (N == this.keys.Length / 4)
                ResetCapacity(keys.Length / 2);
        }
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append($"Capacity: {this.keys.Length}, N: {this.N}");
            builder.Append($"{Environment.NewLine}[ ");
            for (int i = 0; i < N; i++)
            {
                builder.Append(keys[i]);
                if (i < N - 1)
                    builder.Append(", ");
            }
            builder.Append(" ]");
            return builder.ToString();
        }       
    }
}
