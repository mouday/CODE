using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RefOutTest
{
    class Program
    {
        static void ChangeArray(out string[] arr)
        {
            arr = new string[] { "test1","test2","tes3"};
        }
        static void Main(string[] args)
        {
            string[] arr;
            ChangeArray(out arr);
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]+" ");
            }
            Console.ReadKey();
        }
    }
}
