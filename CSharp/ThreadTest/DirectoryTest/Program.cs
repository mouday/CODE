using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic.FileIO;
using System.IO;

namespace DirectoryTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //string sourcePath = @"E:\彭世瑜";
            //string destinationPath = @"d:\target";
            //FileSystem.CopyDirectory(sourcePath,destinationPath,UIOption.AllDialogs);
            string[] lines = { "first line", "second line", "third line" };
            File.WriteAllLines(@"d:\test.txt", lines);

            string text = "I leaning a powerful function in c sharp languge!";
            File.WriteAllText(@"d:\text.txt", text);

            using (StreamWriter writer = new StreamWriter(@"d:\text.txt", true))
            {
                foreach (string line in lines)
                {
                    if (!line.Contains("second"))
                    {
                        writer.WriteLine(line);
                    }
                }
            }
            //read 
            string s = File.ReadAllText(@"d:\text.txt");
            Console.WriteLine(s);

            Console.WriteLine();
            string[] ls = File.ReadAllLines(@"d:\text.txt");
            int i = 0;
            foreach (string l in ls)
            {
                i++;
                Console.WriteLine(i + " \t" + l);
            }

            int counter = 0;
            string current;
            StreamReader reader = new StreamReader(@"d:\text.txt");
            while ((current = reader.ReadLine()) != null)
            {
                Console.WriteLine(current);
                counter++;
            }
            reader.Close();
            Console.WriteLine("there is {0} lines ", counter);
            Console.ReadKey();
        }

    }
}
