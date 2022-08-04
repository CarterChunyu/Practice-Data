using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            Console.WriteLine($"單辭總數:{words.Count}");

            LinkedList3Dictionary<string, int> dic = new LinkedList3Dictionary<string, int>();

            Stopwatch t1 = new Stopwatch();
            t1.Start();
            foreach (var item in words)
            {
                if (dic.Contains(item))
                    dic.Set(item, dic.Get(item) + 1);
                else
                    dic.Add(item, 1);
            }
            t1.Stop();
            Console.WriteLine($"不同單辭總數: {dic.Count}");
            Console.WriteLine($"city出現的詞頻: {dic.Get("city")}");
            Console.WriteLine($"運行時間: {t1.ElapsedMilliseconds} ms");


            //List<string> words =TestHelper.ReadFile("测试文件1/双城记.txt");
            //Console.WriteLine($"單辭總數:{words.Count}");

            //Stopwatch s1 = new Stopwatch();
            //LinkedList1Set<string> l = new LinkedList1Set<string>();
            //s1.Start();
            //foreach (var item in words)
            //{
            //    l.Add(item);
            //}
            //s1.Stop();
            //Console.WriteLine($"不重複單詞總是:{l.Count}");
            //Console.WriteLine($"耗時:{s1.ElapsedMilliseconds} ms");

            //Stopwatch s2 = new Stopwatch();
            //Console.WriteLine();
            //Array1Set<string> a = new Array1Set<string>();
            //s2.Start();
            //foreach (var item in words)
            //{
            //    a.Add(item);
            //}
            //s2.Stop();
            //Console.WriteLine($"不重複單詞總是:{a.Count}");
            //Console.WriteLine($"耗時:{s2.ElapsedMilliseconds} ms");
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
}
