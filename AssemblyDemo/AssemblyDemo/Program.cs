using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace AssemblyDemo
{
    class Program
    {
        static void ShowAssembly(Assembly assembly)
        {
            
            Console.WriteLine($"Assembly: {assembly.FullName}\nFrom GAC? {assembly.GlobalAssemblyCache}\n" +
                $"Path: {assembly.Location}\nVersion: {assembly.ImageRuntimeVersion}\n\n");
            foreach (var module in assembly.Modules)
            {
                Console.WriteLine(module.Name);
            }
        }

        static void Main(string[] args)
        {
            Assembly assembly = Assembly.Load("System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089");
            ShowAssembly(assembly);
            Assembly ourAssembly = Assembly.GetExecutingAssembly();
            ShowAssembly(ourAssembly);
            Console.ReadKey();
        }
    }
}
