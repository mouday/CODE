using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MoveFileTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "test.txt";
            string sourcePath = @"D:\source";
            string targetPath = @"D:\target\test";

            string sourceFile = Path.Combine(sourcePath,fileName);
            string targetFile = Path.Combine(targetPath,fileName);

            //File.Move(sourceFile,targetFile);
            //当文件或文件夹已经存在则不能移动
            Directory.Move(sourcePath, targetPath);

        }
    }
}
