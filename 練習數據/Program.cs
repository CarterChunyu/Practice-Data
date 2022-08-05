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
            List<string> words = TestHelper.ReadFile("测试文件1/双城记.txt");
            Console.WriteLine(words.Count);


            LinkedList1Set<string> l = new LinkedList1Set<string>();
            long t1 = TestSet(l, words);
            Console.WriteLine($"鏈表 耗時: {t1} 個數 :{l.Count}");

            SortedArray1Set<string> s = new SortedArray1Set<string>();
            long t2 = TestSet(s, words);
            Console.WriteLine($"有序數組 耗時: {t2} 個數 :{s.Count}");

            BST1Set<string> b = new BST1Set<string>();
            long t3 = TestSet(b, words);
            Console.WriteLine($"二分 耗時: {t3} 個數 :{b.Count}");


            RBT1Set<string> r = new RBT1Set<string>();
            long t4 = TestSet(r, words);
            Console.WriteLine($"紅黑 耗時: {t4} 個數 :{r.Count}");

            HashSt1Set<string> h = new HashSt1Set<string>();
            long t5 = TestSet(h, words);
            Console.WriteLine($"二分 耗時: {t5} 個數 :{h.Count}");



            //LinkedList3Dictionary<string, int> l = new LinkedList3Dictionary<string, int>();
            //long t1 = TestDictionary(l, words);
            //Console.WriteLine(l.Count);
            //Console.WriteLine($"city {l.Get("city")}");
            //Console.WriteLine($"耗時:{t1}");

            //SortedArray2Dicitonary<string, int> s = new SortedArray2Dicitonary<string, int>();
            //long t2 = TestDictionary(s, words);
            //Console.WriteLine(s.Count);
            //Console.WriteLine($"city {s.Get("city")}");
            //Console.WriteLine($"耗時:{t2}");
        }
        static long TestDictionary(IDictionary<string,int> dic,List<string> words)
        {
            Stopwatch t1 = new Stopwatch();
            t1.Start();
            foreach (string word in words)
            {
                if (!dic.Contains(word))
                    dic.Add(word, 1);
                else
                    dic.Set(word, dic.Get(word) + 1);
            }
            t1.Stop();
            return t1.ElapsedMilliseconds;
        }
        static long TestSet(ISet<string> set,List<string> word)
        {
            Stopwatch t = new Stopwatch();
            t.Start();
            foreach (var item in word)
            {
                set.Add(item);
            }
            t.Stop();
            return t.ElapsedMilliseconds;
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
    class Student : IComparable<Student>
    {
        public Student(string name, int height)
        {
            this.Name = name;
            this.Height = height;
        }
        public string Name { get; set; }
        public int Height { get; set; }

        public int CompareTo(Student other)
        {
            int result = this.Height.CompareTo(other.Height);
            if (result == 0)
                result = this.Name.CompareTo(other.Name);
            return result;
        }
        public override string ToString()
        {
            return $"{this.Name}-{this.Height}";
        }
    }
}
