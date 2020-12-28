using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace AssemblyAttrDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly currentAssembly = Assembly.GetExecutingAssembly();
            Type attributeType = typeof(AssemblyDescriptionAttribute);
            object[] customAttributes = currentAssembly.GetCustomAttributes(attributeType, false);
            if (customAttributes.Length > 0)
            {
                AssemblyDescriptionAttribute assemblyDescriptionAttribute = (AssemblyDescriptionAttribute)customAttributes[0];
                Console.WriteLine("AssemblyDescriptionAttribute description: " + assemblyDescriptionAttribute.Description);
                Console.Read();
            }
        }
    }
}
