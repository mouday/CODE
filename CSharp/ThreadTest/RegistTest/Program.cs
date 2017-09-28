using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace RegistTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Microsoft.Win32.RegistryKey key;
            //key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Names");
            //key.SetValue("Name", "Isabella");
            //key.Close();

            //RegistryKey key = Registry.CurrentUser;
           // string str = Registry.CurrentUser.GetValue("psy").ToString();
            //key.SetValue("name","pengshiyu");
            //key.Close();
            //string str = GetRegistData("name");
            //RegistryKey key = Registry.LocalMachine.OpenSubKey("SOFTWARE",true);
            //RegistryKey k = key.OpenSubKey("xxx",true);
            //string s = k.GetValue("name").ToString();
            //Console.WriteLine(s);
            //RegistryKey

            //create key
            Registry.LocalMachine.CreateSubKey("SOFTWARE\\Test");
            Registry.LocalMachine.CreateSubKey("SOFTWARE\\Test\\Test");
            RegistryKey writekey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Test",true);
            writekey.SetValue("nowtime", System.DateTime.Now.ToString(), RegistryValueKind.String);
            writekey.SetValue("nowtime1", System.DateTime.Now.ToString(), RegistryValueKind.String);
            writekey.SetValue("nowtime2",System.DateTime.Now.ToString(),RegistryValueKind.String);
            writekey.Close();


            //delete key 
            RegistryKey delkey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Test", true);
            string[] keys = delkey.GetValueNames();
            foreach (string k in keys)
            {
                if (k == "nowtime")
                {
                    delkey.DeleteValue("nowtime");
                }
            }
            delkey.Close();


            //read key
            RegistryKey readkey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Test");
            string s1=readkey.GetValue("nowtime1").ToString();
            readkey.Close();
            Console.WriteLine(s1);

            //Registry.LocalMachine.DeleteSubKey("SOFTWARE\\Test");


            
            //delete
            string[] ks = Registry.LocalMachine.OpenSubKey("SOFTWARE").GetSubKeyNames();
            foreach (string s in ks)
            {
                if (s == "Test")
                {
                    Registry.LocalMachine.DeleteSubKeyTree("SOFTWARE\\Test");
                }
            }

            Console.WriteLine("delete successful!");








            //Console.WriteLine(str);
            Console.ReadKey();
        }
        private static string GetRegistData(string name)
        {
            string registData;
            RegistryKey hkml = Registry.LocalMachine;
            RegistryKey software = hkml.OpenSubKey("SOFTWARE", true);
            RegistryKey aimdir = software.OpenSubKey("XXX", true);
            registData = aimdir.GetValue(name).ToString();
            return registData;
        } 


    }
}
