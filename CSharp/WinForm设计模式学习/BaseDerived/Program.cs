using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseDerived
{
    class Program
    {
        static void Main(string[] args)
        {
            //先有鸡还是先有蛋？
            MyBase b = new MyBase();
            MyDerived d = new MyDerived();
            b.d = d;
            Console.WriteLine(b.d.m);
            Console.ReadLine();
        }
    }
}
