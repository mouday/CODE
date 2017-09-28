using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
namespace GetIpAddress
{
    class Program
    {
        static void Main(string[] args)
        {

            string str = GetLocalIp();
            Console.WriteLine(Dns.GetHostName());
            Console.ReadKey();

        }

        public static string GetLocalIp()
        {
            IPAddress localIp = null;
            IPAddress[] ipArray;
            
            ipArray = Dns.GetHostAddresses(Dns.GetHostName());
            //localIp = ipArray.First(ip=>ip.AddressFamily==);
            foreach (IPAddress ip in ipArray)
            {
                Console.WriteLine(ip);
            }
            return"";
        }
    }
}
