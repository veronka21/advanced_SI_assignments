using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Instrumentation2
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!EventLog.SourceExists("Demo2", "DESKTOP-6IT3APF"))
            {
                EventLog.CreateEventSource("Demo2", "X", "DESKTOP-6IT3APF");
            }
            EventLog myLog = new EventLog("X", "DESKTOP-6IT3APF", "Demo2");
            Trace.AutoFlush = true;
            EventLogTraceListener myListener = new EventLogTraceListener(myLog);
            myListener.WriteLine("This is a test");
            var entries = myLog.Entries.Cast<EventLogEntry>()
                          .Select(x => new
                          {
                              x.Message
                          }).ToList();
            foreach (var entry in entries)
            {
                Console.WriteLine(entry.Message);
            }
            Console.ReadKey();
        }
    }
}
