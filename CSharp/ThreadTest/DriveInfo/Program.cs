using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DriveInfoTest
{
    class Program
    {
        static void Main(string[] args)
        {
            DriveInfo di = new DriveInfo(@"c:\");
            Console.WriteLine("DriveFormat:\t{0}",di.DriveFormat);
            Console.WriteLine("DriveType:\t{0}",di.DriveType);
            Console.WriteLine("IsReady:\t{0}",di.IsReady);
            Console.WriteLine("RootDirectory:\t{0}",di.RootDirectory);
            Console.WriteLine("TotalFreeSpace:\t{0}", di.TotalFreeSpace);
            Console.WriteLine("TotalSize:\t{0}", di.TotalSize);
            Console.WriteLine("VolumeLabel:\t{0}", di.VolumeLabel);
            Console.WriteLine();

            //get root directory
            DirectoryInfo dirInfo = di.RootDirectory;
            Console.WriteLine(dirInfo);
            Console.WriteLine(dirInfo.Attributes.ToString());
            Console.WriteLine();

            //get files
            FileInfo[] fileNames = dirInfo.GetFiles("*.*");
            foreach (FileInfo fi in fileNames)
            {
                Console.WriteLine("{0},{1},{2}",fi.Name,fi.LastAccessTime,fi.Length);
            }                   
            Console.WriteLine();

            //get directorys
            DirectoryInfo[] dirInfos = dirInfo.GetDirectories("*.*");
            foreach (DirectoryInfo d in dirInfos)
            {
                Console.WriteLine(d.Name);
            }
            Console.WriteLine();

            //get current application directory
            string currentDirName = Directory.GetCurrentDirectory();
            Console.WriteLine(currentDirName);

            //get a array of file names
            string[] files = Directory.GetFiles(currentDirName,"*.*");
            foreach (string f in files)
            {
                FileInfo fi=null;
                try
                {
                    fi = new FileInfo(f); 
                }
                catch (FileNotFoundException e)
                {

                    Console.WriteLine(e.Message);
                    continue;
                }
                Console.WriteLine("{0},{1}",fi.Name,fi.Directory);
            }

            Console.WriteLine();

            //set current directory
            string path=@"d:\test\test";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            Directory.SetCurrentDirectory(path);
            Console.WriteLine(Directory.GetCurrentDirectory());

            Console.ReadKey();
        }
    }
}
