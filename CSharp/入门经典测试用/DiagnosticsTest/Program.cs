using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagnosticsTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Debug.WriteLine("debug");
            Console.WriteLine("console");
            Trace.WriteLine("trace");
            Console.ReadKey();
        }
    }
}
