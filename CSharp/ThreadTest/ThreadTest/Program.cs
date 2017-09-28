using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadTest
{
    class Program
    {
        public delegate string del(object data);
        static void Main(string[] args)
        {
            //Thread t1 = new Thread(new ThreadStart(TestMethod));
            //Thread t2 = new Thread(new ParameterizedThreadStart(TestMethod));
            //t1.IsBackground = true;
            //t2.IsBackground = true;
            //t1.Start();
            //t2.Start("hello");

            //Console.WriteLine("*****************华丽的分割线******************");
            //ThreadPool.QueueUserWorkItem(TestMethod,"hello");

            Task<int> t = new Task<int>(n => Sum((Int32)n), 10000);
            t.Start();
            //t.Wait();
            //Console.WriteLine(t.Result);
            //一个任务完成时，自动启动一个新任务。 
            Task cwt = t.ContinueWith(task=>Console.WriteLine("the result is {0}",task.Result));

            del d = new del(TestMethod);
            del d1 = TestMethod;
            IAsyncResult result = d.BeginInvoke("thread param",TestCallback,"callback param");
            string str = d.EndInvoke(result);
            Console.WriteLine("str=",str);
            Console.ReadKey();
        }
        //public static void TestMethod()
        //{
        //    Console.WriteLine("不带参数的线程函数");
        //}

        //public static void TestMethod(object data)
        //{
        //    string datastr = data as string;
        //    Console.WriteLine("带参数的线程函数，参数为：{0}",datastr);
        //}
        private static Int32 Sum(Int32 n)
        {
            Int32 sum = 0;
            for (;n>0 ;--n )
            {
                checked { sum += n; }
            }
            return sum;
        }

        public static string TestMethod(object data)
        {
            string datastr = data as string;
            return datastr;
        }
        public static void TestCallback(IAsyncResult data)
        {
            Console.WriteLine(data.AsyncState);
        }
    }
}
