#region using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion
namespace codeLine
{
    enum orientation : byte
    {
        north = 1,
        south = 2,
        east = 3,
        west = 4
    }
    class Program
    {
        static void Main(string[] args)
        {
            //int myInteger;
            //string myString;
            //myString = "\"myInteger\" is ";
            //myInteger = 17;
            //Console.WriteLine(myString);
            //Console.WriteLine("{myString} {myInteger}");

            //ushort destinationVal;
            //char sourceVar='a';
            //destinationVal = sourceVar;
            //Console.WriteLine("sourceVar={0}",sourceVar);
            //Console.WriteLine("destinationVal={0}",destinationVal);


            //byte destinationVal;
            //short sourceVar = 281;
            //destinationVal = checked((byte)sourceVar);
            //Console.WriteLine("sourceVar={0}", sourceVar);
            //Console.WriteLine("destinationVal={0}", destinationVal);


            //orientation myDirection = orientation.north;
            //Console.WriteLine(myDirection);
            //byte mybyte = (byte)myDirection;
            //Console.WriteLine(mybyte);
            //string mystring = Convert.ToString(myDirection);
            //Console.WriteLine(mystring);

            //int[][] arrays = new int[5][];
            //arrays[0] = new int[] { 1 };
            //arrays[1] = new int[] { 1,2,3};
            //arrays[2] = new int[] { 1, 2, 3,4 };
            //arrays[3] = new int[] { 1, 2, 3 ,6,9};
            //arrays[4] = new int[] { 1, 2, 3 ,7,8,9};
            //foreach (int[] array in arrays)
            //{
            //    foreach (int i in array)
            //    {
            //        Console.WriteLine(i);
            //    }
            //}

            string mystring = " This is a String ";
            Console.WriteLine(mystring);
            foreach (char character in mystring)
            {
                Console.WriteLine(character);
            }
            Console.WriteLine(mystring.ToLower());
            Console.WriteLine(mystring.ToUpper());
            char[] chars = mystring.ToCharArray();
            Console.WriteLine(chars[2]);
            Console.WriteLine(mystring.Length);
            Console.WriteLine(mystring.Trim());
            char[] chares = {'g',' ','i'};
            Console.WriteLine(chares.Length);
            Console.WriteLine(mystring.Trim(chares));
            Console.WriteLine(mystring.PadLeft(30,'-'));
            Console.WriteLine(mystring.ToLower());
            Console.WriteLine();
            Console.WriteLine($"ceshi {mystring}");
            Console.ReadKey();
        }
       
    }
}
