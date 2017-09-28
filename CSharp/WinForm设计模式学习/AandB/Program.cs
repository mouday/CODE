using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AandB
{
    class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
            B b = new B();
            a.b = b;
            b.a = a;
        }
    }
}
