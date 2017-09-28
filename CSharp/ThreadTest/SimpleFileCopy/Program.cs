using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SimpleFileCopy
{
    class Program
    {
        static void Main(string[] args)
        {
            ///拷贝单个文件
            string fileName = "test.txt";
            string sourcePath = @"D:\source";
            string targetPath = @"D:\target";

            string sourceFile = Path.Combine(sourcePath,fileName);
            string destFile = Path.Combine(targetPath,fileName);

            if (!Directory.Exists(targetPath))
            {
                Directory.CreateDirectory(targetPath);
            }

            File.Copy(sourceFile,destFile,true);

            ///拷贝多个文件
            if (Directory.Exists(sourcePath))
            {
                string[] files = Directory.GetFiles(sourcePath);

                foreach (string s in files)
                {
                    fileName = Path.GetFileName(s);
                    destFile = Path.Combine(targetPath, fileName);
                    File.Copy(s, destFile, true);
                }

            }
            else {
                Console.WriteLine("source path dose not exist！ ");
            }
            Console.WriteLine("press any key to exit.");
            Console.ReadKey();
        }
    }
}
