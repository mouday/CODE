using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuilderMode
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append('a',2);
            sb.Append('b',3);
            sb.Append('c',4);
            Console.WriteLine(sb);
            sb.Remove(0,sb.Length);
            Console.WriteLine(sb);

            //打印三角形
            Console.WriteLine("请输入行数：");
            int lines = int.Parse(Console.ReadLine());
            Console.WriteLine();
            for (int i = 1; i <= lines; i++)
            {
                for (int j = 1; j <= lines - i; j++)
                {
                    Console.Write(" ");
                }
                for (int k = 1; k <= i * 2 - 1; k++)
                {
                    Console.Write("*");
                   
                }
                Console.WriteLine();
            }
            //biuder模式打印三角形
            StringBuilder mySb =new StringBuilder();
            for (int i = 1; i <= lines; i++)
            {
              
               mySb.Append(' ',lines-i);
               mySb.Append('*',2*i-1);
               mySb.Append("\n");
               //mySb.Remove(0,mySb.Length);
                          
            }
            Console.WriteLine(mySb.ToString());

            Console.ReadKey();
        }
    }
}
