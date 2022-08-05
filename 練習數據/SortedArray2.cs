using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 練習數據
{
    class SortedArray2<Key,Value>where Key:IComparable<Key>
    {
        private Key[] keys;
        private Value[] values;
        private int N;

        public SortedArray2(int capacity)
        {
            this.keys = new Key[capacity];
            this.values = new Value[capacity];
            this.N = 0;
        }
        public SortedArray2() : this(10)
        {

        }
        public int Count { get { return N; } }
        public bool IsEmpty { get { return N == 0; } }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append($"Capacity:{keys.Length} Count:{this.N} {Environment.NewLine}");
            for (int i = 0; i < N; i++)
            {
                builder.Append($"{keys[i]}-{values[i]}");
                if (i < N - 1)
                    builder.Append(", ");
            }
            return builder.ToString();
        }
        public int Rank(Key key)
        {
            int l = 0;
            int r = N - 1;
            while (l <= r)
            {
                int mid = (r - l) / 2 + l;
                if (key.CompareTo(keys[mid]) < 0)
                    r = mid - 1;
                else if (key.CompareTo(keys[mid]) > 0)
                    l = mid + 1;
                else // key.CompareTo(keys[mid])==0
                    return mid;
            }
            return l;
        }
        private void ResetCapacity(int capacity)
        {
            Key[] newKeys = new Key[capacity];
            Value[] newValues = new Value[capacity];

            for (int i = 0; i < N; i++)
            {
                newKeys[i] = keys[i];
                newValues[i] = values[i];
            }
            this.keys = newKeys;
            this.values = newValues;
        }
        public void Add(Key key,Value value)
        {
            int index = Rank(key);
            if (index < N && key.CompareTo(keys[index]) == 0)
                values[index] = value;
            else
            {
                if (N == this.keys.Length)
                    ResetCapacity(2 * this.keys.Length);
                for (int i = N-1; i >=index ; i--)
                {
                    keys[i + 1] = keys[i];
                    values[i + 1] = values[i];
                }
                keys[index] = key;
                values[index] = value;
                N++;
            }
        }
        public void Remove(Key key)
        {
            int index = Rank(key);
            if (index > N || key.CompareTo(keys[index]) != 0)
                return;
            for (int i = index; i < N-1; i++)
            {
                keys[i] = keys[i + 1];
                values[i] = values[i + 1];
            }
            keys[N - 1] = default(Key);
            values[N - 1] = default(Value);
            N--;
            if (N == this.keys.Length / 4)
                ResetCapacity(this.keys.Length / 2);            
        }
        public bool Contains(Key key)
        {
            int index = Rank(key);
            if (index < N && key.CompareTo(keys[index]) == 0)
                return true;
            return false;
        }
        public Value Min()
        {
            if (IsEmpty)
                throw new InvalidOperationException("空數組");
            return values[0];
        }
        public Value Max()
        {
            if (IsEmpty)
                throw new InvalidOperationException("空數組");
            return values[N-1];
        }
        public Value Select(int index)
        {
            if (index < 0 || index >= N)
                throw new ArgumentException("索引越界");
            return values[index];
        }
        public Value Floor(Key key)
        {
            int index = Rank(key);
            if (index < N && key.CompareTo(keys[index]) == 0)
                return values[index];
            if (index == 0)
                throw new ArgumentNullException($"沒有小於或等於{key}的鍵");
            return values[index - 1];
        }
        public Value Ceiling(Key key)
        {
            int index = Rank(key);
            if (index == N)
                throw new ArgumentException($"沒有大於等於{key}的鍵");
            return values[index];
        }
        public Value Get(Key key)
        {
            int index = Rank(key);
            if (index > N || key.CompareTo(keys[index]) != 0)
                throw new ArgumentException($"鍵{key}不存在");
            return values[index];
        }
        public void Set(Key key,Value newValue)
        {
            int index = Rank(key);
            if (index > N || key.CompareTo(keys[index]) != 0)
                throw new ArgumentException($"鍵{key}不存在");
            values[index] = newValue;
        }
        
    }
}
