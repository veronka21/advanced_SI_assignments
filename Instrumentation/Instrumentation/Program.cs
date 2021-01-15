using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Instrumentation
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!EventLog.SourceExists("Demo", "DESKTOP-6IT3APF"))
            {
                EventLog.CreateEventSource("Demo", "Application", "DESKTOP-6IT3APF");
            }
            EventLog logDemo = new EventLog("Application", "DESKTOP-6IT3APF", "Demo");
            logDemo.WriteEntry("Event Written to Application Log",
                              EventLogEntryType.Information,
                              234,
                              Convert.ToInt16(3));
            var entries = logDemo.Entries.Cast<EventLogEntry>()
                                     .Where(x => x.Source == "Demo")
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
