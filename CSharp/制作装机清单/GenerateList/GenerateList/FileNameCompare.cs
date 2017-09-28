using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace FileNameSortBySys
{
    ///<summary>
    ///主要用于文件名的比较。
    ///</summary>
    public class FileNameCompare : IComparer<object>
    {
        //调用DLL  
        [DllImport("Shlwapi.dll", CharSet = CharSet.Unicode)]
        private static extern int StrCmpLogicalW(string param1, string param2);


        //前后文件名进行比较。  
        public int Compare(object name1, object name2)
        {
            if (null == name1 && null == name2)
            {
                return 0;
            }
            if (null == name1)
            {
                return -1;
            }
            if (null == name2)
            {
                return 1;
            }
            return StrCmpLogicalW(name1.ToString(), name2.ToString());
        }
    }
}
