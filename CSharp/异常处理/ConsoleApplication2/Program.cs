using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication2
{
    
    class Program
    {
        private static int ConvertStringToInt(string myStr)
        {
            int outNum = 0;
            try
            {
                outNum = Convert.ToInt32(myStr);
                return outNum;
            }
            catch
            {
                throw new FormatException("格式转换不正确");
            }
        }
        static void Main(string[] args)
        {
            string mystr = "1234f";
            try
            {
                int myint = ConvertStringToInt(mystr);
                Console.WriteLine(myint);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                }
            Console.ReadKey();
        }
    }
}
