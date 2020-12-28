using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace AssemblyTypeInfoDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Windows\Microsoft.NET\Framework64\v4.0.30319\System.ServiceProcess.dll";
            BindingFlags flags = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance;
            Assembly assembly = Assembly.LoadFile(path);
            Console.WriteLine(assembly.FullName);
            Type[] assemblyTypes = assembly.GetTypes();
            foreach (var type in assemblyTypes)
            {
                Console.WriteLine("Type name: " + type.Name);
                MemberInfo[] members = type.GetMembers(flags);
                foreach (var member in members)
                {
                    Console.WriteLine($"{member.MemberType}: {member.Name}");
                }
            }
            Console.ReadKey();
        }
    }
}
