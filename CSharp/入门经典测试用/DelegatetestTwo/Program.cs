using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatetestTwo
{
    class Program
    {
        delegate string MyRead();

        static void Main(string[] args)
        {
            MyRead myWrite = new MyRead(Console.ReadLine);
            string str=myWrite();
            Console.WriteLine(str);
            Console.ReadKey();
        }
    }
}
