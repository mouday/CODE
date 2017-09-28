using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入一个整数：");
            try
            {
                int myint = int.Parse(Console.ReadLine());
                double mydouble = 1.0 / myint;
                Console.WriteLine("{0} 的倒数是： {1}", myint, mydouble);

            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("除零异常");
            }
            catch (OverflowException)
            {
                Console.WriteLine("溢出异常");
            }
            catch (FormatException)
            {
                Console.WriteLine("转换异常");
            }
            catch (Exception)
            {
                Console.WriteLine("其他异常");
            }
            Console.ReadKey();
        }
    }
}
