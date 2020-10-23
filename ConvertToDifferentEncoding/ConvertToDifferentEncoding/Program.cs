using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertToDifferentEncoding
{
    class Program
    {
        static void Main(string[] args)
        {
            FileHandler fileHandler = new FileHandler();
            fileHandler.WriteToFile();
        }
    }
}
