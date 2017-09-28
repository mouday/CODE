using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearnMSDN
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < 100; i++)
            {
                builder.AppendLine(i.ToString());
            }
            Console.WriteLine(builder);
            Console.ReadKey();
        }
    }
}
