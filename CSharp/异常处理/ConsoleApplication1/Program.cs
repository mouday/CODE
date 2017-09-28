using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] myInt = { 0,2,3,4,5,6,8};
            try {
                for (int i = 0; i < myInt.Length; i++)
                {
                    Console.WriteLine("720chuhao{0}={1}",myInt[i],720/myInt[i]);
                }
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            finally {
                Console.WriteLine("执行");
            }
            Console.ReadKey();
        }
    }
}
