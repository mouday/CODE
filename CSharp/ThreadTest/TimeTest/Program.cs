using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace TimeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Stopwatch stopWatch = new Stopwatch();
            //stopWatch.Start();
            //Thread.Sleep(5000);
            //stopWatch.Stop();
            //Console.WriteLine(stopWatch.ElapsedMilliseconds);
            //Console.ReadKey();
            Stopwatch stopwatch = new Stopwatch();
            //第一次计时
            stopwatch.Start();
            Console.WriteLine("Stopwatch is running:{0}", stopwatch.IsRunning);//判断当前Stopwatch的状态
            System.Threading.Thread.Sleep(1000);//耗时操作
            stopwatch.Stop();
            Console.WriteLine("Using Elapsed output runTime:{0}", stopwatch.Elapsed.ToString());//这里使用时间差来输出
            Console.WriteLine("Using ElapsedMilliseconds output runTime:{0}", stopwatch.ElapsedMilliseconds);//这里面使用毫秒来输出
            Console.WriteLine("===================================================");
            //第二次计时
            stopwatch.Start();
            System.Threading.Thread.Sleep(1000);//耗时操作
            stopwatch.Stop();
            Console.WriteLine("The second RunTime:{0}", stopwatch.ElapsedMilliseconds);//这里面使用毫秒来输出
            Console.WriteLine("===================================================");
            //第三次计时（这里使用了Restart）
            stopwatch.Restart();//这里使用Restart来启动计时（会把前面的时间清空）
            System.Threading.Thread.Sleep(1000);//耗时操作
            stopwatch.Stop();
            Console.WriteLine("Using Restart, so runTime:{0}", stopwatch.ElapsedMilliseconds);//这里面使用毫秒来输出
            Console.ReadKey();
        }
    }
}
