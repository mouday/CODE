using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadTestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //1、创建线程
            //Thread t = new Thread(new ThreadStart( Write2));//创建线程
            //t.Start();//执行write2
            //t.Join();//暂停其他线程，直到该线程方法结束
            //同时执行主线程上的该方法
            //for (int i = 0; i < 1000; i++) Console.Write("1");
            //Thread.Sleep(5000);
            //使用lambda
            //Thread t = new Thread(() => Console.WriteLine("new thread"));
            //t.Start();
            //Thread t = new Thread(() => print("hello world!"));
            //t.Start();
            //Thread t = new Thread(print);
            //t.Start("hello world");
            Console.WriteLine("---------------------------");
            //2、CLR使每个线程都有自己独立的内存栈，所以每个线程的本地变量都相互独立。
            //new Thread(Go).Start();
            //Go();
            //Thread.Sleep(TimeSpan.FromSeconds(5));
            Console.WriteLine("---------------------------");
            //3、如果不同线程指向同一个实例的引用，那么不同的线程共享该实例。
            //Program tt = new Program();
            //new Thread(tt.Go).Start();
            //tt.Go();
            //for (int i = 0; i < 10; i++)
            //{
            //    int temp = i;
            //    new Thread(()=>Console.WriteLine(temp)).Start();
            //}
         
           //new Thread(catchException).Start();
            //task任务
           //Task.Factory.StartNew(Write1);    
           //Task t = new Task(Write1);
           //t.Start();
           //Task.Run(new Action(Write1));
            // 创建Task并执行
            //Task<string> task = Task.Factory.StartNew<string>(
            //    ()=>DownloadHtml(@"http://www.baidu.com"));
            //// 同时执行其他方法
            //Write1();
            ////主线程会被阻塞直到获取到该返回值
            //string result = task.Result;
            //Console.WriteLine(result);
            
            //ThreadPool.QueueUserWorkItem(print);
            //ThreadPool.QueueUserWorkItem(print, "pengshiyu");
            //Func<string, int> method = Work;
            //IAsyncResult cookis = method.BeginInvoke("test",null,null);
            //
            // ... 此时可以同步处理其他事情
            //
            //int result = method.EndInvoke(cookis);
            //Console.WriteLine("string length is :"+result);

            //线程阻塞
            //Thread t = new Thread(Write3);
            //Console.WriteLine("t is new ");
            //t.Start();
            //t.Join();
            //Console.WriteLine("t is end");

            //Console.WriteLine("sleep ...");
            //Thread.Sleep(3000);
            //Console.WriteLine("sleep end.");

            //使用4.5框架
            Task task1 = Task.Run(
                () =>
                {
                    Console.WriteLine("task is run...");
                    Thread.Sleep(3000);
                });
            Console.WriteLine(task1.IsCompleted);
            task1.Wait();
            Console.WriteLine(task1.IsCompleted);

            Console.ReadKey();
        }
        static void Write3()
        {
            Console.WriteLine("write3 start...");
        }
        static int Work(string s)
        {
            return s.Length;
        }
        static string DownloadHtml(string url)
        {
            using (var wc = new System.Net.WebClient())
            {
                return wc.DownloadString(url);
            }
        }
        static void Write1()
        {
            Console.WriteLine("hello from Task");
        }
        static void catchException()
        {   try
            {
                throw null;
            }
             catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void print(object  messageObj)
        {
            string message = (string)messageObj;
            Console.WriteLine("hello from thread pool "+message);
        }
        static void Write2()
        {
            for (int i = 0; i < 1000; i++) Console.Write("2");
        }
        static void Go1()
        {
            for (int cycles = 0; cycles < 5; cycles++) Console.WriteLine('N');
        }
        static int j;
        static bool done;
        static readonly object locker = new object();
        static void Go()
        {
            //排他锁，确保一次只有一个线程执行该代码
            lock (locker)
            {
                if (!done)
                {
                    Console.WriteLine("Done");
                    done = true;
                }

            }
        }
    }
}
