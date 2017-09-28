using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RefArrayTest
{
    class Program
    {
        static void PrintArray(string[] arr)
        {
            for (int i = 0; i < arr.Length;i++ )
            {
                Console.Write(arr[i] + "{0}", i < arr.Length ? " " : "");
            }
            Console.WriteLine();
        }

        static void ChangeArray(string[] arr)
        {
            arr = (arr.Reverse()).ToArray();
            Console.WriteLine("arr[0] is {0}",arr[0]);
            PrintArray(arr);
            
        }

        static void ChangeArrayElement(string[] arr)
        {
            arr[0] = "sat";
            arr[1] = "fri";
            arr[2] = "Thu";
            Console.WriteLine("arr[0] is {0}", arr[0]);
        }
        static void Main(string[] args)
        {
            string[] arr = {"sun","mon","tue","wed","sat","fri","thu" };
            PrintArray(arr);

            ChangeArray(arr);

            PrintArray(arr);

            ChangeArrayElement(arr);

            PrintArray(arr);
            Console.ReadKey();
        }

    }
}
