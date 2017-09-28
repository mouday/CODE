using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadLinesTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\PSY\Desktop\test.txt";
            foreach (string line in File.ReadLines(path,Encoding.Default))
            {
                Console.WriteLine(line);
            }
            Console.ReadKey();
        }
    }
}
