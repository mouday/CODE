using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FileNameSortBySys
{
    class Program
    {
        /// <summary>
        /// C#按文件名排序（顺序）
        /// </summary>
        /// <param name="arrFi">待排序数组</param>
        public static void SortAsFileName(ref FileInfo[] arrFi)
        {       
            Array.Sort(arrFi, new FileNameCompare());
            //Array.Sort(arrFi, delegate (FileInfo x, FileInfo y) { return x.Name.CompareTo(y.Name); });
        }


        public static void SortFiles()
        {
            string filePath = @"C:\Users\PSY\Desktop\通用工具箱 V1.3相关\HHLSR04-2017-012-1\HHLSR04-2017-012-1\个人化";
            DirectoryInfo di = new DirectoryInfo(filePath);

            FileInfo[] arrFi = di.GetFiles("*.*");
            SortAsFileName(ref arrFi);          
            for (int i = 0; i < arrFi.Length; i++)
                Console.WriteLine(arrFi[i].Name);
        }
        static void Main(string[] args)
        {
            SortFiles();
        }
    }
}
