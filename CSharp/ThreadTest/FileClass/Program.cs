using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FileClass
{
    class Program
    {
        static System.Collections.Specialized.StringCollection log = new System.Collections.Specialized.StringCollection();
        static void Main(string[] args)
        {
            //获取逻辑分区
            string[] drives = System.Environment.GetLogicalDrives();
            foreach (string d in drives)
            {
                System.IO.DriveInfo di=new System.IO.DriveInfo(d);
               
                //排除
                if (!di.IsReady)
                {
                    Console.WriteLine("drive is not ready:{0}",di);
                    continue;
                }
              
                    Console.WriteLine("drive is ready:{0}", di);
                    DirectoryInfo dirRoot = di.RootDirectory;
                    WalkDirectoryTree(dirRoot);


               
            }
            Console.WriteLine("exception:");
            foreach (string s in log)
            {
                Console.WriteLine(s);
                StreamWriter writer = new StreamWriter(@"C:\Users\PSY\Desktop\list.txt", true, Encoding.Default);
                writer.WriteLine(s);
                writer.Close();
            }
            Console.ReadKey();
        }

        /// <summary>
        /// 遍历文件夹
        /// </summary>
        /// <param name="root"></param>
        public static void WalkDirectoryTree(System.IO.DirectoryInfo root)
        {
            System.IO.FileInfo[] files = null;
            System.IO.DirectoryInfo[] subDirs = null;
            try
            {
                files = root.GetFiles("*.*");
            }
            catch (UnauthorizedAccessException e)
            {
                log.Add(e.Message);
                
            }
            catch(DirectoryNotFoundException e)

            {
                Console.WriteLine(e.Message);
            }
            if (files != null)
            {
                foreach (FileInfo fi in files)
                {
                    Console.WriteLine(fi.FullName);
                    StreamWriter writer = new StreamWriter(@"C:\Users\PSY\Desktop\list.txt",true,Encoding.Default);

                    writer.WriteLine(fi.FullName);
                    writer.Close();
                }
                //递归调用
                subDirs = root.GetDirectories();
                foreach (DirectoryInfo dirInfo in subDirs)
                {
                    WalkDirectoryTree(dirInfo);
                }
            }

        }
    }
}
