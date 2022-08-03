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
