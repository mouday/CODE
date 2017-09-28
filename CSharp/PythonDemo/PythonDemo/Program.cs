using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PythonDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            ScriptRuntime pyRunTime = Python.CreateRuntime();
            dynamic obj = pyRunTime.UseFile("hello.py");

            Console.WriteLine(obj.welcome("Nick"));
            Console.WriteLine(obj.add(1,3));
            Console.ReadKey();
        }
    }
}
