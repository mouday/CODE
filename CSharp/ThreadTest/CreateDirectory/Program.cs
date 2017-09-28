using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CreateDirectoryTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string folderName = @"D:\test";
            string path1 = Path.Combine(folderName, "test1");
            Console.WriteLine(path1);
            string path2 = @"D:\test\test2";
            Directory.CreateDirectory(path1);

            //string fileName = Path.GetRandomFileName();
            string fileName = "mytest.txt";
            string path = Path.Combine(path1,fileName);
            Console.WriteLine("path:{0}",path);

            if (!File.Exists(path))
            {
                using (FileStream fs = File.Create(path))
                {
                    for (byte i = 0; i < 100; i++)
                    {
                        fs.WriteByte(i);
                    }
                }
            }
            else {
                Console.WriteLine("file already exists:{0}",path);
                //return;
            }
            try
            {
                byte[] buffer = File.ReadAllBytes(path);
                foreach (byte b in buffer)
                {
                    Console.Write(b+" ");

                }
                Console.WriteLine();
            }
            catch (IOException e)
            {

                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
