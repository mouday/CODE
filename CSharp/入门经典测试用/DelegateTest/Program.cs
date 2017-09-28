using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DelegateTest
{
    class Program
    {
        delegate double processDelegate(double param1,double param2);
        static double Multiply(double param1, double param2) => param1 * param2;
        static double Divide(double param1, double param2) => param1 / param2;
        static void Write(params int[] vals)
        {
            foreach (int val in vals) Console.WriteLine(val);   
        }
        public static void Method() => Console.WriteLine("method is ok");
        static void Main(string[] args)
        {
            processDelegate process;
            Console.WriteLine("enter 2 number with a comma:");
            string input = Console.ReadLine();
            int pos = input.IndexOf(',');
            double param1 = Convert.ToDouble(input.Substring(0,pos));
            double param2 = Convert.ToDouble(input.Substring(pos+1,input.Length-pos-1));

            Console.WriteLine("enter m to multiply or d to divide:");
            input = Console.ReadLine();
            if (input == "m")
            {
                process = new processDelegate(Multiply);
            }
            else
            {
                process =new processDelegate( Divide);
            }
            Console.WriteLine($"result={process(param1,param2)}");
            Console.WriteLine("============");
            Write(1,2,3,4,5,6,5,6);
            Console.ReadKey();
        }
    }
}
