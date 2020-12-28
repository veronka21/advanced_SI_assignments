using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace DynamicCodeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Windows\Microsoft.NET\Framework64\v4.0.30319\System.Web.dll";
            Assembly assembly = Assembly.LoadFile(path);
            Type type = assembly.GetType("System.Web.HttpUtility");
            MethodInfo encode = type.GetMethod("HtmlEncode", new Type[] { typeof(string) });
            MethodInfo decode = type.GetMethod("HtmlDecode", new Type[] { typeof(string) });
            string toBeEncoded = "New <string> to be encoded";
            Console.WriteLine(toBeEncoded);
            string encoded = (string)encode.Invoke(null, new object[] { toBeEncoded });
            Console.WriteLine(encoded);
            string decoded = (string)decode.Invoke(null, new object[] { encoded });
            Console.WriteLine(decoded);
            Console.ReadKey();
        }
    }
}
