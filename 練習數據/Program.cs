using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 練習數據
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedArray1<int> s = new SortedArray1<int>();
            int[] nums = { 7, 9, 11, 5, 2, 1,36,44,11,12,12,18,42, 0 };
            foreach (var item in nums)
            {
                s.Add(item);
            }
            Console.WriteLine(s);
            s.Remove(0);
            s.Remove(9);
            s.Remove(11);
            s.Remove(10000);
            Console.WriteLine(s);

        }
        static long TestQueue(IQueue<int> queue,int n)
        {
            Stopwatch s = new Stopwatch();
            s.Start();
            for (int i = 0; i < n; i++)
            {
                queue.Enqueue(i);
            }
            for (int i = 0; i < n; i++)
            {
                queue.Dequeue();
            }
            s.Stop();
            return s.ElapsedMilliseconds;
        }

        static long TestStack(IStack<int> stack,int n)
        {
            Stopwatch s = new Stopwatch();
            s.Start();
            for (int i = 0; i < n; i++)
            {
                stack.Push(i);
            }
            for (int i = 0; i < n; i++)
            {
                stack.Pop();
            }
            s.Stop();
            return s.ElapsedMilliseconds;
        }
    }
    class TestSearch
    {
        public static int[] ReadFile(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            List<int> l = new List<int>();
            while (!sr.EndOfStream)
            {
                string line= sr.ReadLine();
                l.Add(int.Parse(line));
            }
            fs.Close();
            sr.Close();
            return l.ToArray();
        }
        public static int FullSearch(int target,int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == target)
                    return i;
            }
            return -1;
        }
        public static int BinarySearch(int target,int[] arr)
        {
            int l = 0;
            int r = arr.Length - 1;
            while (l <= r)
            {
                int mid = (r - l) / 2 + l;
                if (target == arr[mid])
                    return mid;
                else if (target < arr[mid])
                    r = mid - 1;
                else // target>arr[mid]
                    l = mid + 1;
            }
            return -1;
        }
    }
}
