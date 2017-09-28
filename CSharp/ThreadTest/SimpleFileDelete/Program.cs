using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SimpleFileDelete
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = @"d:\test\test.txt";
            //if (File.Exists(fileName))
            //{
            //    try
            //    {
            //        File.Delete(fileName);
            //    }
            //    catch (IOException e)
            //    {

            //        Console.WriteLine(e.Message);
            //    }
                
            //}
            //Console.ReadKey();
            //FileInfo fi = new FileInfo(fileName);
            //try
            //{
            //    fi.Delete();
            //}
            //catch (IOException e)
            //{

            //    Console.WriteLine(e.Message);
            //}
            string path = @"d:\test";
            //if (Directory.Exists(path))
            //{
            //    try
            //    {
            //        Directory.Delete(path);
            //    }
            //    catch (IOException e)
            //    {

                    
            //    }
            //}
            DirectoryInfo di = new DirectoryInfo(path);
            try
            {
                di.Delete(true);
            }
            catch (IOException e)
            {               
                throw;
            }
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
