using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArraysTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] scores = new int[] { 48, 95, 12, 266, 45, 89 };

            IEnumerable<int> scoreQuery =
                from score in scores
                where score > 80
                select score;

            foreach (int i in scoreQuery)
            {
                Console.WriteLine(i);
            }


            Console.WriteLine("length of array is :{0}", scores.Length);
            Console.WriteLine("rank of array is {0}", scores.Rank);

            int[] array = new int[5];
            foreach (int a in array)
            {
                Console.WriteLine(a);
            }

            string[] stringArray = new string[5];
            foreach (string s in stringArray)
            {
                Console.WriteLine(s);
            }

            int[, ,] array3D = 
            { 
             {
             {1,2,3},
             {4,5,6}
             },
             {{7,8,9},{10,11,12}},
             {{13,14,15},{16,17,18}}
            };
            Console.WriteLine("{0},{1},{2}",array3D.Length,array3D.Rank,array3D.GetLength(2));

            int[][] jaggedArray = new int[3][];
            jaggedArray[0] = new int[3];
            jaggedArray[1] = new int[4];
            jaggedArray[2] = new int[5];

            int[][] arr =new int[2][];
            arr[0] = new int[3] { 1,2,3};
            arr[1] = new int[4] { 4, 5, 6, 7 };
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("elementL{0}: ",i);
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.Write("{0}{1}",arr[i][j],j==(arr[i].Length-1)?"":" ");
                }
            }
            Console.WriteLine();
            Console.WriteLine();
            int[,] arr1 = { {1,2},{3,4},{5,6}};
            foreach (int i in arr1)
            {
                Console.WriteLine(i);
            }

                Console.ReadKey();

        }
    }
}
