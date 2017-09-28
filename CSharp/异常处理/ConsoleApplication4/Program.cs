using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication4
{
    class Program
    {
        static void Main(string[] args)
        {
            //bool mybool = true;
            //try
            //{
            //    char mychar = Convert.ToChar(mybool);
            //    Console.WriteLine(mychar);
            //}
            //catch (InvalidCastException ex)

            //{

            //    Console.WriteLine(ex.Message);
            //}
            //string[] mystr = { "cat","dog","pig"};
            //object[] myobj = mystr;
            //try
            //{
            //    foreach (object obj in myobj)
            //    {
            //        Console.WriteLine(obj);
            //        Console.WriteLine(obj.GetType());
            //        myobj[2] = 13;
            //    }
            //}
            //catch (ArrayTypeMismatchException ex)
            //{

            //    Console.WriteLine(ex.Message);
            //}
            try
            {
                int num = 10;
                string mystr = "自定义的异常";
                //Console.WriteLine(num/0);
                throw new MyException(mystr);
                Console.WriteLine("由于引发了异常，这行代码不会被执行");
            }
            catch (MyException ex)
            {

                Console.WriteLine(ex.Message);
            }
            //DivideByZeroException
            //
            //OverflowException
            //FormatException
            //byte mybyte = Convert.ToByte(Console.ReadLine());
            Console.ReadKey();
        }
    }
}
