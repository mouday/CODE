using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FileNameSortBySys
{
    class FileNameSort
    {
        /// <summary>
        /// C#按文件名排序（顺序）
        /// </summary>
        /// <param name="arrFi">待排序数组</param>
       

        public static FileInfo[]  SortFiles(FileInfo[] arrFi)
        {
            Array.Sort(arrFi, new FileNameCompare());
            return arrFi;
        }
    }
}
