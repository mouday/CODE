using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FileTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] drives = System.Environment.GetLogicalDrives();
            foreach (string s in drives)
            {
                DriveInfo dirInfo =new DriveInfo(s);
                if (!dirInfo.IsReady)
                {
                    Console.WriteLine("not ready:"+s);
                    continue;
                }
                Console.WriteLine("is ready:"+s);
                DirectoryInfo dirs = dirInfo.RootDirectory;
                WalkDirectoryTree(dirs);
            }
        }
        private static void WalkDirectoryTree(DirectoryInfo dir)
        {
            FileInfo[] fileInfo = dir.GetFiles();
            DirectoryInfo[] directoryInfo = dir.GetDirectories();
            foreach(FileInfo f in fileInfo)
            {
                Console.WriteLine(f.FullName);
            }
            foreach (DirectoryInfo d in directoryInfo)
            {
                Console.WriteLine(d.FullName);

            }
        }
    }
}
