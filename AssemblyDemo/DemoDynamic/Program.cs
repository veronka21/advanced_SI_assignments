using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Reflection.Emit;

namespace DemoDynamic
{
    class Program
    {
        static void Main(string[] args)
        {
            AssemblyName assemblyName = new AssemblyName();
            assemblyName.Name = "Bumblebee tuna";
            assemblyName.Version = new Version("1.0.0.0");
            AppDomain currentAppDomain = AppDomain.CurrentDomain;
            AssemblyBuilder assemblyBuilder = currentAppDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.ReflectionOnly);
            ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("CodeModule", "DemoAssembly.dll");
            TypeBuilder typeBuilder = moduleBuilder.DefineType("Animal", TypeAttributes.Public);
            Type animal = typeBuilder.CreateType();
            foreach (var memberInfo in animal.GetMembers())
            {
                Console.WriteLine($"Member {memberInfo.MemberType}: {memberInfo.Name}");
            }
            Console.ReadKey();
        }
    }
}
