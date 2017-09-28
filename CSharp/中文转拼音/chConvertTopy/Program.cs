using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chConvertTopy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("欢迎使用中文转拼音系统\n==========================");
            while (true)
            {

                Console.WriteLine("\n请输入一个中文字符串：");
                string input = Console.ReadLine();

                EcanConvertToCh ec = new EcanConvertToCh();
                string pingyin = ec.convertCh(input);
                Console.WriteLine("\n拼音：" + pingyin);

                Console.WriteLine("\n拼音首字母：" + PinYin.GetCodstring(input));
            }
            Console.ReadKey();
        }
    }
}
