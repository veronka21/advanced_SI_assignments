using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Management;

namespace PerformanceCounterDemo2
{
    class Program
    {
        public static void WriteToEventLog()
        {
            WqlEventQuery demoQuery = new WqlEventQuery("__InstanceCreationEvent",
                          new TimeSpan(0, 0, 1),
                          "TargetInstance isa \"Win32_Process\"");
            ManagementEventWatcher demoWatcher = new ManagementEventWatcher();
            demoWatcher.Query = demoQuery;
            demoWatcher.Options.Timeout = new TimeSpan(0, 0, 30);
            Console.WriteLine("Open an application to trigger an event.");
            ManagementBaseObject e = demoWatcher.WaitForNextEvent();

            if (!EventLog.SourceExists("Demo4", "DESKTOP-6IT3APF"))
            {
                EventLog.CreateEventSource("Demo4", "Chap10Demo", "DESKTOP-6IT3APF");
            }

            EventLog demoLog = new EventLog("Chap10Demo");
            demoLog.Source = "Demo4";
            String eventName = ((ManagementBaseObject)e["TargetInstance"])["Name"].ToString();
            Console.WriteLine(eventName);
            demoLog.WriteEntry(eventName, EventLogEntryType.Information);
            demoWatcher.Stop();
        }

        static void Main(string[] args)
        {
            WriteToEventLog();
            Console.ReadLine();
        }
    }
}
