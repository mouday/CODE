using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = "";
            string b = "xxoo";
            Console.WriteLine(b.Contains(a));
            Console.WriteLine(b.IndexOf(a)>-1);
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("test", "text");
            dict.Add("test", "tex1");//有异常
            Console.WriteLine(dict["test"]);
            Console.ReadKey();
        }
    }
}
