using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeekAndArchive
{
    class Program
    {
        public static void runSearch(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Two command arguments should be given when running the program: \n" +
                    "1.: the searched file's name\n" +
                    "2.: the directory to be searched");
                Console.ReadKey();
            } else
            {
                var files = FileSearchInDirectory.Search(args[0], args[1]);
                foreach (var file in files)
                {
                    Console.WriteLine(file);
                }
                Console.WriteLine("End of task");
                Console.ReadKey();
            }
        }

        static void Main(string[] args)
        {
            runSearch(args);
        }
    }
}
