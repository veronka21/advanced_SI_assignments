using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Timers;

namespace PerformanceCounterDemo
{
    class Program
    {
        private static PerformanceCounter HeapCounter = new PerformanceCounter(".NET CLR Memory", "# Bytes in all Heaps");
        private static PerformanceCounter ExceptionCounter = new PerformanceCounter(".NET CLR Exceptions", "# of Exceps Thrown");
        private static Timer DemoTimer = new Timer(3000);

        private static void OnTick(object source, ElapsedEventArgs e)
        {
            Console.WriteLine("# of Bytes in all Heaps : " + HeapCounter.NextValue().ToString());
            Console.WriteLine("# of Framework Exceptions Thrown : " + ExceptionCounter.NextValue().ToString());
        }

        static void Main(string[] args)
        {
            DemoTimer.Elapsed += new ElapsedEventHandler(OnTick);
            DemoTimer.Enabled = true;
            HeapCounter.InstanceName = "_Global_";
            ExceptionCounter.InstanceName = "_Global_"; 
            Console.WriteLine("Press [Enter] to Quit Program");
            Console.ReadLine();
        }
    }
}
