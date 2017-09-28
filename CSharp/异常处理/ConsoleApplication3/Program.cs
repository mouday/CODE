using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication3
{
    class Program
    {
        static int DivideByTwo(int num)
        {
            if (num % 2 == 1) 
            {
                throw new ArgumentException("此处必须为偶数");
            }
            return num / 2;
        }
        static void Main(string[] args)
        {
            //int[] myInt = { 0, 2, 3, 4, 5, 6, 8 };
            //try
            //{
            //    for (int i = 0; i <= myInt.Length; i++)
            //    {
            //        Console.WriteLine(myInt[i]);
            //    }
            //}
            //catch (IndexOutOfRangeException e) { Console.WriteLine(e.Message); }
            //finally
            //{
            //    Console.WriteLine("执行");
            //}
            //string s = null;
            //try
            //{
            //    Console.WriteLine(s.ToString());
            //}
            //catch(NullReferenceException ex)
            //{ 
            
            //}
            try
            {
                Console.WriteLine(DivideByTwo(9));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            //InvalidCastException
            Console.ReadKey();
        }
    }
    
}
